using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hst.Domain.Model;

namespace Hst.Storage.Mappings
{
    [Serializable]
    public class ChoreAssignmentMapping : EntityMapping<ChoreAssignment>
    {
        public ChoreAssignmentMapping()
        {
            Property(ca => ca.AssignedDate)
                .IsRequired();

            Property(ca => ca.IsApproved)
                .IsRequired();

            Property(ca => ca.IsComplete)
                .IsRequired();

            HasRequired(ca => ca.Student);

            HasRequired(ca => ca.Chore);

            HasOptional(ca => ca.ApprovedBy);
            
        }
    }
}
