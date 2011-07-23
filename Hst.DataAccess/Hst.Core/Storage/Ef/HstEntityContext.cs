using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace Hst.Core.Storage.Ef
{
    public class HstEntityContext : ObjectContext
    {
        private readonly Dictionary<Type, object> _entitySets;

        public HstEntityContext(EntityConnection connection)
            : base(connection)
        {
            _entitySets = new Dictionary<Type, object>();
            if (!DatabaseExists())
            {
                CreateDatabase();
            }
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<HstEntityContext>());
        }

        public ObjectSet<T> EntitySet<T>()
            where T : class, IEntity
        {
            var t = typeof(T);
            object match;

            if (!_entitySets.TryGetValue(t, out match))
            {
                match = CreateObjectSet<T>();
                _entitySets.Add(t, match);
            }

            return (ObjectSet<T>)match;
        }
    }
}
