using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injectamundo
{
    public partial class Container
    {
        internal List<Registration> registrations = new List<Registration>();
        internal InstanceProducer instanceProducer = new InstanceProducer();
        internal bool containerClosed = false;

        public Container()
        {

        }
    }
}
