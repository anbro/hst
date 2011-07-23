using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Hst.Domain.Model
{
    [Serializable]
    [DataContract(Namespace = DomainConstants.DataContractNamespace, IsReference = true)]
    public class Chore : Entity
    {
        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual int PointValue { get; set; }

        [DataMember]
        public virtual int ChoreFrequency { get; set; }

        public Frequency Frequency { 
            get
            {
                return (Model.Frequency) ChoreFrequency;
            } 
            set
            {
                ChoreFrequency = (int) value;
            } 
        }
    }

    [Serializable]
    public enum Frequency
    {
        ThriceDaily,
        TwiceDaily,
        Daily,
        Weekly,
        BiWeekly,
        Monthly
    }
}
