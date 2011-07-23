using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hst.Domain.Model;

namespace Hst.Storage.Mappings
{
    [Serializable]
    public class ChoreMapping : EntityMapping<Chore>
    {
        public ChoreMapping()
        {
            Property(c => c.ChoreFrequency)
                .IsRequired();

            Property(c => c.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(250);

            Property(c => c.PointValue)
                .IsRequired();


        }
    }
}
