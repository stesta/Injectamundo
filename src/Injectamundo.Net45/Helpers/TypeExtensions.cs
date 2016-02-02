using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Injectamundo
{
    public static class TypeExtensions
    {
        public static bool IsConcrete(this Type type)
        {
            return type.IsClass && !type.IsAbstract && !type.IsInterface;
        }
    }
}
