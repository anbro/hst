using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Hst.Domain.Model
{
    [Serializable]
    [DataContract(Namespace = DomainConstants.DataContractNamespace, IsReference = true)]
    public class Student : Entity
    {
        public Student()
        {
            AssociatedUsers = new List<User>();
            TestResults = new List<TestResult>();
            Activities = new List<Activity>();
            Lessons = new List<Lesson>();
            AssignedChores = new List<ChoreAssignment>();
        }

        [DataMember]
        public virtual string NameFirst { get; set; }

        [DataMember]
        public virtual string NameLast { get; set; }

        [DataMember]
        public virtual DateTime DateOfBirth { get; set; }

        [DataMember]
        public virtual School School { get; set; }

        [DataMember]
        public virtual IList<User> AssociatedUsers { get; set; }

        [DataMember]
        public virtual IList<TestResult> TestResults { get; set; }

        [DataMember]
        public virtual IList<Activity> Activities { get; set; }

        [DataMember]
        public virtual IList<Lesson> Lessons { get; set; }

        [DataMember]
        public virtual IList<ChoreAssignment> AssignedChores { get; set; }


    }
}
