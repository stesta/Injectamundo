using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injectamundo
{
    public class SingletonLifestyle : Lifestyle
    {
        private Dictionary<Type, object> cache = new Dictionary<Type, object>();

        public override string Name
        {
            get { return "Singleton"; }
        }

        public override object GetInstance(System.Reflection.ConstructorInfo constructor, object[] parameters = null)
        {
            if (cache.ContainsKey(constructor.DeclaringType))
            {
                return cache[constructor.DeclaringType];
            }

            var dependencies = constructor.GetParameters();
            if (dependencies.Count() == 0)
            {
                var instance = Activator.CreateInstance(constructor.DeclaringType);
                cache.Add(constructor.DeclaringType, instance);

                return instance;
            }
            else
            {
                if (parameters == null || parameters.Count() != dependencies.Count())
                {
                    throw new Exception("Incorrect number of parameters to invoke instance.");
                }

                var instance = constructor.Invoke(parameters);
                cache.Add(constructor.DeclaringType, instance);

                return instance;
            }
        }
    }
}
