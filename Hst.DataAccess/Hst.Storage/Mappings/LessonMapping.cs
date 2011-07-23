using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hst.Domain.Model;

namespace Hst.Storage.Mappings
{
    [Serializable]
    public class LessonMapping : EntityMapping<Lesson>
    {
        public LessonMapping()
        {
            Property(l => l.LessonDate)
                .IsRequired();

            Property(l => l.LessonTitle)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(250);

            Property(l => l.Notes)
                .IsRequired()
                .IsUnicode();

            Property(l => l.TimeSpent)
                .IsRequired();

            HasRequired(l => l.RecordedBy);
            //    .WithRequiredDependent();

            HasMany(l => l.Subjects)
                .WithMany();
            //    .WithRequired();


        }
    }
}
