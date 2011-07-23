using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Hst.Domain.Model
{
    [Serializable]
    [DataContract(Namespace = DomainConstants.DataContractNamespace, IsReference = true)]
    public class User : Entity
    {
        public User()
        {
            AccessibleStudents = new List<Student>();
            
        }

        [DataMember]
        public virtual string Login { get; set; }

        [DataMember]
        public virtual string Email { get; set; }

        [DataMember]
        public virtual string NameFirst { get; set; }

        [DataMember]
        public virtual string NameLast { get; set; }

        [DataMember]
        public virtual bool IsActive { get; set; }

        [DataMember]
        public virtual bool IsTeacher { get; set; }

        [DataMember]
        public virtual School School { get; set; }

        [DataMember]
        public virtual IList<Student> AccessibleStudents { get; set; }
    }
}
