using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hst.Domain.Model;

namespace Hst.Storage.Mappings
{
    [Serializable]
    public class ActivityMapping : EntityMapping<Activity>
    {
        public ActivityMapping()
        {
            Property(a => a.ActivityName)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode();

            Property(a => a.Notes)
                .IsRequired()
                .IsUnicode();

            Property(a => a.TimeSpent)
                .IsRequired();

            Property(a => a.ActivityDate)
                .IsRequired();

            //HasMany(a => a.Students)
            //    .WithMany();

            HasMany(a => a.Subjects)
                .WithMany();

            HasRequired(a => a.RecordedBy);




        }
    }
}
