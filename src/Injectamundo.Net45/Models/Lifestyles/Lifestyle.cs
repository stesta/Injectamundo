using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Injectamundo
{
    public abstract class Lifestyle
    {
        public Lifestyle(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public abstract object GetInstance(ConstructorInfo constructor, object[] parameters = null);

        public static readonly Lifestyle Transient = new TransientLifestyle();

        public static readonly Lifestyle Singleton = new SingletonLifestyle();
    }
}
