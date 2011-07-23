using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Text;
using Hst.Core.Validation.Attributes;
using Hst.Domain.Resources;

namespace Hst.Domain.Model
{
    [Serializable]
    [DataContract(Namespace = DomainConstants.DataContractNamespace, IsReference = true)]
    public class School : Entity
    {
        public School()
        {
            Users = new List<User>();
            Students = new List<Student>();
        }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ValidationMessages),
            ErrorMessageResourceName = "SchoolRequiresName")]
        [StringRange(ErrorMessageResourceType = typeof(ValidationMessages),
            ErrorMessageResourceName = "SchoolNameLength", MaxLength = 100, MinLength = 0)]
        [DataMember]
        public virtual string SchoolName { get; set; }

        [DataMember]
        public virtual DateTime JoinedOn { get; set; }

        [DataMember]
        public virtual IList<User> Users { get; private set; }

        [DataMember]
        public virtual IList<Student> Students { get; set; }
    }
}
