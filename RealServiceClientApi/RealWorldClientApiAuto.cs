﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://www.fonllow.com/demo/RealWorldService/Data/2012/08", ClrNamespace="Fonlow.RealWorldService.ClientData")]

namespace Fonlow.RealWorldService.ClientData
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://www.fonllow.com/demo/RealWorldService/Data/2012/08")]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private bool BoolValueField;
        
        private string StringValueField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue
        {
            get
            {
                return this.BoolValueField;
            }
            set
            {
                this.BoolValueField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue
        {
            get
            {
                return this.StringValueField;
            }
            set
            {
                this.StringValueField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Evil666Error", Namespace="http://www.fonllow.com/demo/RealWorldService/Data/2012/08")]
    public partial class Evil666Error : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string MessageField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message
        {
            get
            {
                return this.MessageField;
            }
            set
            {
                this.MessageField = value;
            }
        }
    }
}

namespace Fonlow.RealWorldService.Clients
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.fonllow.com/demo/RealWorldService/2012/08", ConfigurationName="Fonlow.RealWorldService.Clients.IService1")]
    public interface IService1
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.fonllow.com/demo/RealWorldService/2012/08/IService1/GetData", ReplyAction="http://www.fonllow.com/demo/RealWorldService/2012/08/IService1/GetDataResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Fonlow.RealWorldService.ClientData.Evil666Error), Action="http://www.fonllow.com/demo/RealWorldService/2012/08/IService1/GetDataEvil666Erro" +
            "rFault", Name="Evil666Error", Namespace="http://www.fonllow.com/demo/RealWorldService/Data/2012/08")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.fonllow.com/demo/RealWorldService/2012/08/IService1/GetData", ReplyAction="http://www.fonllow.com/demo/RealWorldService/2012/08/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.fonllow.com/demo/RealWorldService/2012/08/IService1/GetDataUsingDataCo" +
            "ntract", ReplyAction="http://www.fonllow.com/demo/RealWorldService/2012/08/IService1/GetDataUsingDataCo" +
            "ntractResponse")]
        Fonlow.RealWorldService.ClientData.CompositeType GetDataUsingDataContract(Fonlow.RealWorldService.ClientData.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.fonllow.com/demo/RealWorldService/2012/08/IService1/GetDataUsingDataCo" +
            "ntract", ReplyAction="http://www.fonllow.com/demo/RealWorldService/2012/08/IService1/GetDataUsingDataCo" +
            "ntractResponse")]
        System.Threading.Tasks.Task<Fonlow.RealWorldService.ClientData.CompositeType> GetDataUsingDataContractAsync(Fonlow.RealWorldService.ClientData.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.fonllow.com/demo/RealWorldService/2012/08/IService1/GetHardData", ReplyAction="http://www.fonllow.com/demo/RealWorldService/2012/08/IService1/GetHardDataRespons" +
            "e")]
        string GetHardData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.fonllow.com/demo/RealWorldService/2012/08/IService1/GetHardData", ReplyAction="http://www.fonllow.com/demo/RealWorldService/2012/08/IService1/GetHardDataRespons" +
            "e")]
        System.Threading.Tasks.Task<string> GetHardDataAsync(int value);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Fonlow.RealWorldService.Clients.IService1, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Fonlow.RealWorldService.Clients.IService1>, Fonlow.RealWorldService.Clients.IService1
    {
        
        public Service1Client()
        {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public string GetData(int value)
        {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value)
        {
            return base.Channel.GetDataAsync(value);
        }
        
        public Fonlow.RealWorldService.ClientData.CompositeType GetDataUsingDataContract(Fonlow.RealWorldService.ClientData.CompositeType composite)
        {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<Fonlow.RealWorldService.ClientData.CompositeType> GetDataUsingDataContractAsync(Fonlow.RealWorldService.ClientData.CompositeType composite)
        {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public string GetHardData(int value)
        {
            return base.Channel.GetHardData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetHardDataAsync(int value)
        {
            return base.Channel.GetHardDataAsync(value);
        }
    }
}
