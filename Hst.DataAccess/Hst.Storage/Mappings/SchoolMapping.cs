using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hst.Domain.Model;

namespace Hst.Storage.Mappings
{
    [Serializable]
    public class SchoolMapping : EntityMapping<School>
    {
        public SchoolMapping()
        {
            Property(u => u.SchoolName)
                .HasMaxLength(100)
                .IsRequired();

            Property(u => u.JoinedOn)
                .IsRequired();


        }
    }
}
