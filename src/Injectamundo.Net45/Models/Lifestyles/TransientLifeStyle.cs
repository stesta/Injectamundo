using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injectamundo
{
    public class TransientLifeStyle : ILifeStyle
    {
        public  string Name
        {
            get
            {
                return "Transient";
            }
        }

        public object ProduceInstance(Container container, Registration registration)
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

            // todo: resolve constructor to use in a better way
            // todo: check for cyclic dependenciess
            var firstConstructor = resolveType.GetConstructors().First();
            var constructorParams = firstConstructor.GetParameters();

            if (constructorParams.Count() == 0)
                return Activator.CreateInstance(resolveType);

            IList<object> parameters = new List<object>();
            foreach (var parameterToResolve in constructorParams)
            {
                var paramRegistration = container.GetRegistration(parameterToResolve.ParameterType);
                parameters.Add(ProduceInstance(container, paramRegistration));
            }

            return firstConstructor.Invoke(parameters.ToArray());
        }
    }
}
