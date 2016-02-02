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
            var registration = GetRegistration(typeof(TService));
            var instance = instanceProducer.Produce(this, registration);

            return instance as TService;
        }
    }
}
