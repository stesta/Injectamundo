using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Injectamundo
{
    public sealed class InstanceProducer
    {
        internal List<Lifestyle> lifestyleCache = new List<Lifestyle>();

        public object Produce(Container container, Registration registration)
        {
            // try to product via the specific producer
            if (registration.ImplementationProducer != null)
            {
                return registration.ImplementationProducer.Invoke();
            }

            // otherwise always try and resolve as many parameters as possible
            Type resolveType = registration.ImplementationType;
            var constructors = resolveType.GetConstructors().OrderByDescending(c => c.GetParameters().Count());
            foreach (var constructor in constructors)
            {
                try
                {
                    return Produce(container, registration, constructor);
                }
                catch 
                {
                }
            }

            // if we make it here for some reason it's an error
            throw new Exception(string.Format("Could not resolve type {0}", registration.ServiceType.FullName));
        }

        private object Produce(Container container, Registration registration, ConstructorInfo constructor)
        {
            var dependencies = constructor.GetParameters();
            var cache = GetCachedLifestyle(registration.Lifestyle);

            if (dependencies.Count() == 0)
            {
                return cache.GetInstance(constructor);
            }

            IList<object> parameters = new List<object>();
            foreach (var dependency in dependencies)
            {
                var paramRegistration = container.GetRegistration(dependency.ParameterType);
                parameters.Add(Produce(container, paramRegistration));
            }

            return cache.GetInstance(constructor, parameters.ToArray());
        }

        private Lifestyle GetCachedLifestyle(Lifestyle lifestyle)
        {
            if (!lifestyleCache.Contains(lifestyle, new LifestyleComparer()))
            {
                lifestyleCache.Add(lifestyle);
            }

            return lifestyleCache.SingleOrDefault(cache => cache.GetType() == lifestyle.GetType());
        }
    }
}
