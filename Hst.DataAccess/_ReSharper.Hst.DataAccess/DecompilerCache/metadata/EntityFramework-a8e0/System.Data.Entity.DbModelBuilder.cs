// Type: System.Data.Entity.DbModelBuilder
// Assembly: EntityFramework, Version=4.1.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Program Files (x86)\Microsoft ADO.NET Entity Framework 4.1\Binaries\EntityFramework.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace System.Data.Entity
{
    public class DbModelBuilder
    {
        public DbModelBuilder();
        public DbModelBuilder(DbModelBuilderVersion modelBuilderVersion);
        public virtual ConventionsConfiguration Conventions { get; }
        public virtual ConfigurationRegistrar Configurations { get; }
        public virtual DbModelBuilder Ignore<T>() where T : class;
        public virtual DbModelBuilder Ignore(IEnumerable<Type> types);
        public virtual EntityTypeConfiguration<TEntityType> Entity<TEntityType>() where TEntityType : class;
        public virtual ComplexTypeConfiguration<TComplexType> ComplexType<TComplexType>() where TComplexType : class;
        public virtual DbModel Build(DbConnection providerConnection);
        public virtual DbModel Build(DbProviderInfo providerInfo);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType();
    }
}
