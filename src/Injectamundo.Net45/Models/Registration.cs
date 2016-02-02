using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injectamundo
{
    public class Registration
    {
        public Registration(Type serviceType, Type implementationType, Lifestyle lifestyle = null)
        {
            ServiceType = serviceType;
            ImplementationType = implementationType;
            Lifestyle = lifestyle ?? Lifestyle.Transient;
        }

        public Type ServiceType { get; private set; }
        public Type ImplementationType { get; private set; }
        public Lifestyle Lifestyle { get; private set; }
    }
}
