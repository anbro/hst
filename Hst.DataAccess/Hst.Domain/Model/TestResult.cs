using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Hst.Domain.Model
{
    [Serializable]
    [DataContract(Namespace = DomainConstants.DataContractNamespace, IsReference = true)]
    public class TestResult : Entity
    {
        [DataMember]
        public virtual int Correct { get; set; }

        [DataMember]
        public virtual int NotAnswered { get; set; }

        [DataMember]
        public virtual int Incorrect { get; set; }

        [DataMember]
        public virtual Student Student { get; set; }

        [DataMember]
        public virtual Test Test { get; set; }
    }
}
