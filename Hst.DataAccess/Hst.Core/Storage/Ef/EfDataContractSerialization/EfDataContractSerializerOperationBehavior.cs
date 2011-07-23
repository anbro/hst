using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Xml;

namespace Hst.Core.Storage.Ef.EfDataContractSerialization
{
    public class EfDataContractSerializerOperationBehavior : DataContractSerializerOperationBehavior
    {
        public EfDataContractSerializerOperationBehavior(OperationDescription operation)
            : base(operation)
        {
        }

        public EfDataContractSerializerOperationBehavior(OperationDescription operation, DataContractFormatAttribute dataContractFormatAttribute)
            : base(operation, dataContractFormatAttribute)
        {
        }

        public override XmlObjectSerializer CreateSerializer(Type type, string name, string ns, IList<Type> knownTypes)
        {
            return new DataContractSerializer(type, name, ns, MergeKnownTypesWithDynamicProxyTypes(knownTypes));
        }

        public override XmlObjectSerializer CreateSerializer(Type type, XmlDictionaryString name, XmlDictionaryString ns, IList<Type> knownTypes)
        {
            return new DataContractSerializer(type, name, ns, MergeKnownTypesWithDynamicProxyTypes(knownTypes));
        }

        private static IEnumerable<Type> MergeKnownTypesWithDynamicProxyTypes(IEnumerable<Type> knownTypes)
        {
            var tmp = new HashSet<Type>();

            if (knownTypes != null)
                tmp.UnionWith(knownTypes);

            tmp.UnionWith(EfDynamicProxyAssemblies.GetTypes());

            return tmp;
        }
    }
}
