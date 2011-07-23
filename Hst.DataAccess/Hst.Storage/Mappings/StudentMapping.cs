using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hst.Domain.Model;

namespace Hst.Storage.Mappings
{
    [Serializable]
    public class StudentMapping : EntityMapping<Student>
    {
        public StudentMapping()
        {
            Property(a => a.DateOfBirth)
                .IsRequired();

            Property(a => a.NameFirst)
                .IsRequired()
                .HasMaxLength(100);

            Property(a => a.NameLast)
                .IsRequired()
                .HasMaxLength(100);

            HasMany(a => a.Activities)
                .WithMany(s => s.Students);

            HasMany(a => a.Lessons)
                .WithMany(s => s.Students);

            HasMany(a => a.TestResults)
                .WithRequired(s => s.Student);

            HasMany(a => a.AssignedChores)
                .WithRequired(s => s.Student);

            HasRequired(a => a.School)
                .WithMany(s => s.Students);



        }
    }
}
