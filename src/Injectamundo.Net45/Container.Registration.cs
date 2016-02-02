using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injectamundo
{
    partial class Container
    {
        public void Register<TService, TImplementation>(Lifestyle lifestyle = null)
            where TImplementation : class, TService
            where TService : class
        {
            if (containerClosed)
            {
                throw new Exception("The container is closed for registration.");
            }

            var registrationAlreadyExists = registrations.Exists(r => r.ServiceType == typeof(TService));
            if (!registrationAlreadyExists)
            {
                var registration = new Registration(typeof(TService), typeof(TImplementation), lifestyle);
                registrations.Add(registration);
            }
        }

        public void Register<TService, TImplementation>(Func<TImplementation> instanceProducer, Lifestyle lifestyle = null)
            where TImplementation : class, TService
            where TService : class
        {
            if (containerClosed)
            {
                throw new Exception("The container is closed for registration.");
            }

            var registrationAlreadyExists = registrations.Exists(r => r.ServiceType == typeof(TService));
            if (!registrationAlreadyExists)
            {
                var registration = new Registration(typeof(TService), instanceProducer, lifestyle);
                registrations.Add(registration);
            }
        }

        internal Registration GetRegistration(Type serviceType)
        {
            var registration = registrations.SingleOrDefault(c => c.ServiceType == serviceType);

            if (registration == null && serviceType.IsValidImplementationType())
            {
                registration = new Registration(serviceType, serviceType);
            }

            if (registration == null)
            {
                throw new Exception("Could not resolve type.");
            }

            return registration;
        }
    }
}
