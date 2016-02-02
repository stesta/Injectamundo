using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injectamundo
{
    public class LifestyleComparer : IEqualityComparer<Lifestyle>
    {
        public bool Equals(Lifestyle x, Lifestyle y)
        {
            return x.GetType() == y.GetType();
        }

        public int GetHashCode(Lifestyle obj)
        {
            return obj.GetHashCode();
        }
    }
}
