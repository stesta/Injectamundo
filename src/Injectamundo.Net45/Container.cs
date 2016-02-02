using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injectamundo
{
    public partial class Container
    {
        private List<Registration> registrations = new List<Registration>();
        private bool containerClosed = false;

        public Container()
        {

        }
    }
}
