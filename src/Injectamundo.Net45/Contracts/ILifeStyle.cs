using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injectamundo
{
    public interface ILifeStyle
    {
        string Name { get; }
        object ProduceInstance(Container container, Registration registration);
    }
}
