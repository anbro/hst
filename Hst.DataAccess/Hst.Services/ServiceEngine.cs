using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hst.Core.IoC;

namespace Hst.Services
{
    public class ServiceEngine
    {
        private static readonly ServiceEngine _instance;

        public static ServiceEngine Instance
        {
            get { return _instance; }
        }

        public IComponentContainer IoC { get; private set; }

        static ServiceEngine()
        {
            _instance = new ServiceEngine();
        }

        private ServiceEngine()
        {
            IoC = new ServiceComponentContainer();
        }
    }
}
