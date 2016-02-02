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
        private string _constructor = string.Empty;

        public AlphaService()
        {
            _constructor = "AlphaService()";
        }

        public AlphaService(BetaService dependency)
        {
            _constructor = string.Format("AlphaService({0})", dependency.ToString());
        }

        public string Name
        {
            get
            {
                return "AlphaService";
            }
        }

        public override string ToString()
        {
            return _constructor;
        }
    }

    public class BetaService : ITypeService
    {
        private string _constructor = string.Empty;

        public BetaService()
        {
            _constructor = "BetaService()";
        }

        public BetaService(string constructorUsed)
        {
            _constructor = string.Format("BetaService({0})", constructorUsed);
        }

        public string Name
        {
            get
            {
                return "BetaService";
            }
        }

        public override string ToString()
        {
            return _constructor;
        }
    }
}
