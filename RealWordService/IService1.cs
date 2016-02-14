using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Fonlow.Demo.RealWordService
{
    [ServiceContract(Namespace = "http://www.fonllow.com/demo/RealWorldService/2012/08")]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations
    [DataContract(Namespace = "http://www.fonllow.com/demo/RealWorldService/Data/2012/08")]
    public class CompositeType
    {

        [DataMember]
        public bool BoolValue
        {
            get;
            set;
        }

        [DataMember]
        public string StringValue
        {
            get;
            set;
        }
    }
}
