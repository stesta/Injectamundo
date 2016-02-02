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
        public abstract string Name { get; }

        public abstract object GetInstance(ConstructorInfo constructor, object[] parameters = null);

        public static readonly Lifestyle Transient = new TransientLifestyle();

        public static readonly Lifestyle Singleton = new SingletonLifestyle();
    }
}
