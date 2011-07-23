using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace Hst.Core.Storage.Ef.EfDataContractSerialization
{
    [Serializable]
    public class EfDataContractSerializerAttribute : Attribute, IOperationBehavior
    {
        private readonly EfDataContractSerializerOperationBehavior _innerOperationBehavior;

        public EfDataContractSerializerAttribute()
        {
        }

        public EfDataContractSerializerAttribute(OperationDescription operation)
        {
            _innerOperationBehavior = new EfDataContractSerializerOperationBehavior(operation);
        }

        public EfDataContractSerializerAttribute(OperationDescription operation, DataContractFormatAttribute dataContractFormatAttribute)
        {
            _innerOperationBehavior = new EfDataContractSerializerOperationBehavior(operation, dataContractFormatAttribute);
        }

        public void Validate(OperationDescription operationDescription)
        {
            if (_innerOperationBehavior == null)
                return;

            (_innerOperationBehavior as IOperationBehavior).Validate(operationDescription);
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            ReplaceDataContractSerializerOperationBehavior(operationDescription);
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            ReplaceDataContractSerializerOperationBehavior(operationDescription);
        }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
            if (_innerOperationBehavior == null)
                return;

            (_innerOperationBehavior as IOperationBehavior).AddBindingParameters(operationDescription, bindingParameters);
        }

        private void ReplaceDataContractSerializerOperationBehavior(OperationDescription description)
        {
            var operationBehavior = description.Behaviors.Find<DataContractSerializerOperationBehavior>();

            if (operationBehavior == null)
                return;

            description.Behaviors.Remove(operationBehavior);
            description.Behaviors.Add(new EfDataContractSerializerOperationBehavior(description));
        }
    }
}
