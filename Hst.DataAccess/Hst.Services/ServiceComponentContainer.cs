using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hst.Core.IoC;
using Hst.Core.Storage;
using Hst.Core.Storage.Ef;
using Hst.Storage.Mappings;
using StructureMap.Attributes;

namespace Hst.Services
{
    public class ServiceComponentContainer : StructureMapComponentContainer
    {
        protected override void BootstrapContainer()
        {
            //Register EfEntityContextBuilder as Singleton, since this contains mapping
            //informations etc to build a new ObjectContext.
            Container.Configure(x => x
                .ForRequestedType<HstEntityContextBuilder>()
                .CacheBy(InstanceScope.Singleton)
                .TheDefault.Is.OfConcreteType<HstEntityContextBuilder>()
                .WithCtorArg("connectionStringName").EqualTo("DB1")
                .OnCreation(builder => builder.MapEntities<IEntityMapping>()));

            //EfEntityContext - Is injected into the EfEntityStore configured below.
            //EfEntityStore is actually just a wrapper around the Context.
            //Should get a new per request since it is our Unit of work.
            Container.Configure(x => x
                .ForRequestedType<HstEntityContext>()
                .CacheBy(InstanceScope.PerRequest)
                .TheDefault.Is.ConstructedBy(() => Resolve<HstEntityContextBuilder>().CreateContext())
                .OnCreation<HstEntityContext>(ec =>
                {
                    ec.ContextOptions.LazyLoadingEnabled = true;
                    ec.ContextOptions.ProxyCreationEnabled = true;
                    
                }));

            //EntityStore - Should get a new per request since it is
            //a wrapper around the EfEntityContext above.
            Container.Configure(x => x
                .ForRequestedType<IEntityStore>()
                .CacheBy(InstanceScope.PerRequest)
                .TheDefault.Is.OfConcreteType<HstEntityStore>());

        }
    }
}
