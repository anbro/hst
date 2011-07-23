using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hst.Domain.Model;

namespace Hst.Storage.Mappings
{
    [Serializable]
    public class ImageMapping : EntityMapping<Image>
    {
        public ImageMapping()
        {
            Property(i => i.File)
                .IsRequired();

        }
    }
}
