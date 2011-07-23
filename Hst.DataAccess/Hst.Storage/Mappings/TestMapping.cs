using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hst.Domain.Model;

namespace Hst.Storage.Mappings
{
    [Serializable]
    public class TestMapping : EntityMapping<Test>
    {
        public TestMapping()
        {
            Property(t => t.Questions)
                .IsRequired();

            Property(t => t.TestDate)
                .IsRequired();

            Property(t => t.TestName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(250);

            HasMany(t => t.Results)
                .WithRequired(r => r.Test);

            HasMany(t => t.Subjects).WithMany();

            HasRequired(t => t.RecordedBy)
                .WithMany();

        }
    }
}
