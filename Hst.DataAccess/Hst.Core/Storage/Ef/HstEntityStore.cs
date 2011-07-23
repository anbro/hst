using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace Hst.Core.Storage.Ef
{
    public class HstEntityStore : IEntityStore
    {
        protected HstEntityContext HstEntityContext { get; private set; }

        public HstEntityStore(HstEntityContext efEntityContext)
        {
            HstEntityContext = efEntityContext;
        }

        public void Dispose()
        {
            HstEntityContext.Dispose();
        }

        public void EnsureDatabaseExists()
        {
            if (HstEntityContext.DatabaseExists())
                return;

            HstEntityContext.CreateDatabase();
        }

        public void EnsureCleanDatabaseExists()
        {
            if (HstEntityContext.DatabaseExists())
                HstEntityContext.DeleteDatabase();

            HstEntityContext.CreateDatabase();
        }

        public void AttachEntityAsModified<T>(T entity) where T : class, IEntity
        {
            HstEntityContext.EntitySet<T>().Attach(entity);
            HstEntityContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }

        public void DetachEntity<T>(T entity) where T : class, IEntity
        {
            HstEntityContext.EntitySet<T>().Detach(entity);
        }

        public void AddEntity<T>(T entity) where T : class, IEntity
        {
            HstEntityContext.EntitySet<T>().AddObject(entity);
        }

        public void DeleteEntity<T>(T entity) where T : class, IEntity
        {
            HstEntityContext.EntitySet<T>().DeleteObject(entity);
        }

        public IQueryable<T> Query<T>() where T : class, IEntity
        {
            return HstEntityContext.EntitySet<T>();
        }

        public IQueryable<T> Query<T>(params string[] includes) where T : class, IEntity
        {
            if (includes == null || includes.Length < 1)
                return Query<T>();

            return includes.Aggregate(HstEntityContext.EntitySet<T>() as ObjectQuery<T>, (current, include) => current.Include(include));
        }

        public int SaveChanges()
        {
            return HstEntityContext.SaveChanges();
        }
    }
}
