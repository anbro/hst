using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Hst.Domain.Model
{
    [Serializable]
    [DataContract(Namespace = DomainConstants.DataContractNamespace, IsReference = true)]
    public class Image : Entity
    {
        [DataMember]
        public byte[] File { get; set; }
    }
}
