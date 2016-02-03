using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Injectamundo
{
    public class TransientLifestyle : Lifestyle
    {
        public TransientLifestyle() : base("Transient")
        {
        }

        public override object GetInstance(Func<object> instanceProducer)
        {
            return instanceProducer.Invoke();
        }

        public override object GetInstance(ConstructorInfo constructor, object[] parameters = null)
        {
            var dependencies = constructor.GetParameters();
            if (dependencies.Count() == 0)
            {
                return Activator.CreateInstance(constructor.DeclaringType);
            }

            if (parameters == null || parameters.Count() != dependencies.Count())
            {
                throw new Exception("Incorrect number of parameters to invoke instance.");
            }

            return constructor.Invoke(parameters);
        }
    }
}
