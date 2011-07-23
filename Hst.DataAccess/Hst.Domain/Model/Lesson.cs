using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Hst.Domain.Model
{
    [Serializable]
    [DataContract(Namespace = DomainConstants.DataContractNamespace, IsReference = true)]
    public class Lesson : Entity
    {
        public Lesson()
        {
            Subjects = new List<Subject>();
            Students = new List<Student>();
        }

        [DataMember]
        public virtual string LessonTitle { get; set; }

        [DataMember]
        public virtual string Notes { get; set; }

        [DataMember]
        public virtual DateTime LessonDate { get; set; }

        [DataMember]
        public virtual int TimeSpent { get; set; }

        [DataMember]
        public virtual IList<Subject> Subjects { get; set; }

        [DataMember]
        public virtual IList<Student> Students { get; set; }

        [DataMember]
        public virtual User RecordedBy { get; set; }
            
    }
}
