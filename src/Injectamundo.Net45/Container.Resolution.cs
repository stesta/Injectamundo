using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injectamundo
{
    partial class Container
    {
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
