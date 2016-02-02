using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injectamundo.Net45.Tests
{
    public interface ITypeService
    {
        string Name { get; }
    }

    public class AlphaService : ITypeService
    {
        public string Name
        {
            get
            {
                return "AlphaService";
            }
        }
    }

    public class BetaService : ITypeService
    {
        public string Name
        {
            get
            {
                return "BetaService";
            }
        }
    }
}
