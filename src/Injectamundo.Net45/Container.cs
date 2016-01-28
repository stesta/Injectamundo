using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injectamundo
{
    public class Container
    {
        private List<Registration> registrations = new List<Registration>();

        public Container()
        {

        }

        internal Registration GetRegistration(Type serviceType)
        {
            var registration = registrations.SingleOrDefault(c => c.ServiceType == serviceType);

            // todo: if registration is null and type is concrete return registration for the concrete type
            //if (registrations == null && registration is concrete type )
            // return new Registration of Concrete Type

            return registration;
        }

        public void Register<TService, TImplementation>()
            where TImplementation : class, TService
            where TService : class
        {
            var registration = new Registration(typeof(TService), typeof(TImplementation), new TransientLifeStyle());
            // todo: check if a registration already exists
            registrations.Add(registration);
        }

        public TService GetInstance<TService>()
            where TService : class
        {
            var registration = registrations.Single(r => r.ServiceType == typeof(TService));
            var lifestyle = registration.Lifestyle;
            var instance = lifestyle.ProduceInstance(this, registration);

            return instance as TService;
        }
    }
}
