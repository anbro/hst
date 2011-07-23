using System;
using System.Collections.Generic;
using StructureMap;
using System.Linq;
using System.Text;

namespace Hst.Core.IoC
{
    public abstract class StructureMapComponentContainer : IComponentContainer
    {
        protected IContainer Container { get; private set; }

        protected StructureMapComponentContainer()
        {
            Container = new Container();

            BootstrapContainer();
        }

        protected abstract void BootstrapContainer();

        public T Resolve<T>()
        {
            return Container.GetInstance<T>();
        }
    }
}
