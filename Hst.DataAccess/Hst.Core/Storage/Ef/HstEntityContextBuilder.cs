using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity.Design.PluralizationServices;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Data.Entity;

namespace Hst.Core.Storage.Ef
{
    public class HstEntityContextBuilder : DbModelBuilder
    {
        private readonly Type _type;
        private readonly DbProviderFactory _factory;
        private readonly ConnectionStringSettings _cnStringSettings;
        private readonly PluralizationService _pluralizer;

        public HstEntityContextBuilder(string connectionStringName)
        {
            _type = GetType();
            _cnStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
            _factory = DbProviderFactories.GetFactory(_cnStringSettings.ProviderName);
            _pluralizer = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>
        /// Creates a new <see cref="ObjectContext"/>.
        /// </summary>
        /// <returns></returns>
        public HstEntityContext CreateContext()
        {
            var cn = _factory.CreateConnection();
            cn.ConnectionString = _cnStringSettings.ConnectionString;

            DbModel dbm = Build(cn);
            return dbm.Compile().CreateObjectContext<HstEntityContext>(cn);
        }

        /// <summary>
        /// Maps the entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="configuration">The configuration.</param>
        public void MapEntity<TEntity>(EntityTypeConfiguration<TEntity> configuration)
            where TEntity : class, IEntity
        {
            RegisterEntity(configuration);

        }

        /// <summary>
        /// Maps the entities in the passed assembly. The classes that
        /// contains the mappings must directly extend <see cref="EntityConfiguration{TEntity}"/>
        /// and may not be abstract and must end with the suffix <![CDATA["Mapping"]]>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public void MapEntities(Assembly assembly)
        {
            MapEntities(GetMappingTypes(assembly));
        }

        /// <summary>
        /// Maps the entities that exists in the assembly for
        /// the specified generic interface-type. The generic interface-type is
        /// also used as a filter, so your mapping-classes needs to implement them.
        /// The mapping classes must directly extend <see cref="EntityConfiguration{TEntity}"/>
        /// and may not be abstract and must end with the suffix <![CDATA["Mapping"]]>.
        /// </summary>
        /// <typeparam name="TFilter"></typeparam>
        public void MapEntities<TFilter>()
        {
            var filterType = typeof(TFilter);
            MapEntities(GetMappingTypes(filterType.Assembly, filterType));
        }

        private IEnumerable<Type> GetMappingTypes(Assembly assembly, Type filterInterfaceType = null)
        {
            var types = assembly.GetTypes().Where(a => a.Name.EndsWith("Mapping") && a.IsClass && !a.IsAbstract);

            if (filterInterfaceType == null)
                return types;

            if (!filterInterfaceType.IsInterface)
                throw new ArgumentException("The sent filterInterfaceType is not of an Interface.", "filterInterfaceType");

            return types.Where(t => t.GetInterfaces().Contains(filterInterfaceType));
        }

        private void MapEntities(IEnumerable<Type> mappingTypes)
        {
            var method = _type.GetMethod("MapEntity");

            foreach (var mappingType in mappingTypes)
            {
                var entityConfigurationType = mappingType.BaseType;
                var entityType = entityConfigurationType.GetGenericArguments()[0];
                var generic = method.MakeGenericMethod(entityType);
                generic.Invoke(this, new[] { Activator.CreateInstance(mappingType) });
            }
        }

        /// <summary>
        /// Registers the entity by setting up a set and configurations for it.
        /// If no configuration is passed, only a Set will be registrered.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entityConfiguration">The entity configuration.</param>
        public void RegisterEntity<TEntity>(EntityTypeConfiguration<TEntity> entityConfiguration = null)
            where TEntity : class, IEntity
        {
            //var pluralizedSetName = _pluralizer.Pluralize(typeof(TEntity).Name);

            //RegisterSet<TEntity>(pluralizedSetName);

            if (entityConfiguration != null)
                Configurations.Add(entityConfiguration);
        }
    }
}
