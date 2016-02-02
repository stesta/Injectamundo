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
        public static bool IsValidImplementationType(this Type type)
        {
            var isPrimitive = type.IsPrimitive || type.IsValueType || (type == typeof(string));
            return type.IsClass && !type.IsAbstract && !type.IsInterface && !isPrimitive;
        }
    }
}
