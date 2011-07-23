using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hst.Core.IoC
{
    public interface IComponentContainer
    {
        T Resolve<T>();
    }
}
