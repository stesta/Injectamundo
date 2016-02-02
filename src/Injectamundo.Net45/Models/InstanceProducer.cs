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
            Type resolveType = null;
            
            try
            {
                resolveType = registration.ImplementationType;
            }
            catch
            {
                throw new Exception(string.Format("Could not resolve type {0}", registration.ServiceType.FullName));
            }

            var constructor = GetConstructor(container, resolveType);
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

        private ConstructorInfo GetConstructor(Container container, Type type)
        {
            var constructors = type.GetConstructors();

            // todo: resolve constructor to use in a better way
            // todo: check for cyclic dependencies
            var constructor = constructors.First();

            return constructor;
        }
    }
}
