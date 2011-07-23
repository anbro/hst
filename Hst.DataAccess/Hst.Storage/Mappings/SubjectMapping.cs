using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hst.Domain.Model;

namespace Hst.Storage.Mappings
{
    [Serializable]
    public class SubjectMapping : EntityMapping<Subject>
    {
        public SubjectMapping()
        {
            Property(s => s.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);

        }
    }
}
