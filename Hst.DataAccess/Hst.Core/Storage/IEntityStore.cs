using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hst.Core.Storage
{
    /// <summary>
    /// Defines an Entitystore that is used to handle persistancy,
    /// CRUD-operations, for Entities.
    /// </summary>
    public interface IEntityStore : IDisposable
    {
        void EnsureDatabaseExists();

        void EnsureCleanDatabaseExists();

        void AttachEntityAsModified<T>(T entity) where T : class, IEntity;

        void DetachEntity<T>(T entity) where T : class, IEntity;

        void AddEntity<T>(T entity) where T : class, IEntity;

        void DeleteEntity<T>(T entity) where T : class, IEntity;

        IQueryable<T> Query<T>() where T : class, IEntity;

        IQueryable<T> Query<T>(params string[] includes) where T : class, IEntity;

        int SaveChanges();
    }
}
