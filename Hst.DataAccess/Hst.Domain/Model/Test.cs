using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Hst.Domain.Model
{
    [Serializable]
    [DataContract(Namespace = DomainConstants.DataContractNamespace, IsReference = true)]
    public class Test : Entity
    {
        public Test()
        {
            Subjects = new List<Subject>();
            Results = new List<TestResult>();
        }

        [DataMember]
        public virtual string TestName { get; set; }

        [DataMember]
        public virtual int Questions { get; set; }

        [DataMember]
        public virtual DateTime TestDate { get; set; }

        [DataMember]
        public virtual User RecordedBy { get; set; }

        [DataMember]
        public virtual IList<Subject> Subjects { get; set; }

        [DataMember]
        public virtual IList<TestResult> Results { get; set; }
    }
}
