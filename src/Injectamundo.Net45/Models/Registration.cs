using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injectamundo
{
    public class Registration
    {
        public Registration(Type serviceType, Type implementationType, ILifeStyle lifestyle = null)
        {
            ServiceType = serviceType;
            ImplementationType = implementationType;
            Lifestyle = lifestyle ?? new TransientLifeStyle();
        }

        public Type ServiceType { get; private set; }
        public Type ImplementationType { get; private set; }
        public ILifeStyle Lifestyle { get; private set; }
    }
}
