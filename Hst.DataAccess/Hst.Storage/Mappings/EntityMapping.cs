using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Data.Metadata.Edm;
using Hst.Domain.Model;

namespace Hst.Storage.Mappings
{
    [Serializable]
    public abstract class EntityMapping<TEntity>
        : EntityTypeConfiguration<TEntity>, IEntityMapping
        where TEntity : Entity
    {
        protected EntityMapping()
        {
            HasKey(u => u.Id);


            Property(u => u.ConcurrencyToken)
                .IsRequired()
                .IsConcurrencyToken()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
                .HasColumnType("timestamp");


        }
    }
}
