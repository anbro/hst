using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Data.Objects;
using Hst.Domain.Model;

namespace Hst.Storage.Mappings
{
    [Serializable]
    public class UserMapping : EntityMapping<User>
    {
        public UserMapping()
        {
            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);

            Property(u => u.Login)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.NameFirst)
                .IsRequired()
                .HasMaxLength(50);

            Property(u => u.NameLast)
                .IsRequired()
                .HasMaxLength(50);

            HasRequired(u => u.School).WithMany(s => s.Users).WillCascadeOnDelete(false);
                
            //    .WithRequiredDependent();

            HasMany(u => u.AccessibleStudents)
                .WithMany(a => a.AssociatedUsers);


        }
    }
}
