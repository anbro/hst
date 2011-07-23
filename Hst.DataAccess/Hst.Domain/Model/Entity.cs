using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Hst.Core;

namespace Hst.Domain.Model
{
    [Serializable]
    [DataContract(Namespace=DomainConstants.DataContractNamespace, IsReference=true)]
    public abstract class Entity : IEntity
    {
        [DataMember]
        public virtual int Id { get; set; }

        [DataMember]
        public virtual byte[] ConcurrencyToken { get; set; }
    }
}
