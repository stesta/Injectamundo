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
            Registration registration = GetRegistration(typeof(TService));

            var lifestyle = registration.Lifestyle;
            var instance = lifestyle.ProduceInstance(this, registration);

            return instance as TService;
        }
    }
}
