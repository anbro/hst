using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Hst.Domain.Model
{
    [Serializable]
    [DataContract(Namespace = DomainConstants.DataContractNamespace, IsReference = true)]
    public class ChoreAssignment : Entity
    {
        [DataMember]
        public virtual Student Student { get; set; }

        [DataMember]
        public virtual Chore Chore { get; set; }

        [DataMember]
        public virtual DateTime AssignedDate { get; set; }

        [DataMember]
        public virtual User ApprovedBy { get; set; }

        [DataMember]
        public virtual bool IsApproved { get; set; }
        
        [DataMember]
        public virtual bool IsComplete { get; set; }
    }
}
