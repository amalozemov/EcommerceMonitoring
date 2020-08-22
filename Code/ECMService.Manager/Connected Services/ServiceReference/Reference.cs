﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ECMService.Manager.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EcmData", Namespace="http://schemas.datacontract.org/2004/07/ECMService.Storage")]
    [System.SerializableAttribute()]
    public partial class EcmData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EndPointIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> HttpErrorsCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> MemoryUsageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> ProcessorTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<ECMService.Manager.ServiceReference.LanDeviceStatus> StatusLanDeviceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TypeMonitorField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EndPointId {
            get {
                return this.EndPointIdField;
            }
            set {
                if ((this.EndPointIdField.Equals(value) != true)) {
                    this.EndPointIdField = value;
                    this.RaisePropertyChanged("EndPointId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> HttpErrorsCount {
            get {
                return this.HttpErrorsCountField;
            }
            set {
                if ((this.HttpErrorsCountField.Equals(value) != true)) {
                    this.HttpErrorsCountField = value;
                    this.RaisePropertyChanged("HttpErrorsCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> MemoryUsage {
            get {
                return this.MemoryUsageField;
            }
            set {
                if ((this.MemoryUsageField.Equals(value) != true)) {
                    this.MemoryUsageField = value;
                    this.RaisePropertyChanged("MemoryUsage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> ProcessorTime {
            get {
                return this.ProcessorTimeField;
            }
            set {
                if ((this.ProcessorTimeField.Equals(value) != true)) {
                    this.ProcessorTimeField = value;
                    this.RaisePropertyChanged("ProcessorTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<ECMService.Manager.ServiceReference.LanDeviceStatus> StatusLanDevice {
            get {
                return this.StatusLanDeviceField;
            }
            set {
                if ((this.StatusLanDeviceField.Equals(value) != true)) {
                    this.StatusLanDeviceField = value;
                    this.RaisePropertyChanged("StatusLanDevice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TypeMonitor {
            get {
                return this.TypeMonitorField;
            }
            set {
                if ((this.TypeMonitorField.Equals(value) != true)) {
                    this.TypeMonitorField = value;
                    this.RaisePropertyChanged("TypeMonitor");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LanDeviceStatus", Namespace="http://schemas.datacontract.org/2004/07/ECMonitoring.Core")]
    public enum LanDeviceStatus : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Sleep = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Connect = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Disconnect = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Break = 3,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IConnectors")]
    public interface IConnectors {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConnectors/DoWork", ReplyAction="http://tempuri.org/IConnectors/DoWorkResponse")]
        int DoWork(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConnectors/DoWork", ReplyAction="http://tempuri.org/IConnectors/DoWorkResponse")]
        System.Threading.Tasks.Task<int> DoWorkAsync(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConnectors/GetDataByEndPointId", ReplyAction="http://tempuri.org/IConnectors/GetDataByEndPointIdResponse")]
        ECMService.Manager.ServiceReference.EcmData GetDataByEndPointId(int endPointId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConnectors/GetDataByEndPointId", ReplyAction="http://tempuri.org/IConnectors/GetDataByEndPointIdResponse")]
        System.Threading.Tasks.Task<ECMService.Manager.ServiceReference.EcmData> GetDataByEndPointIdAsync(int endPointId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConnectors/GetDataByServiceId", ReplyAction="http://tempuri.org/IConnectors/GetDataByServiceIdResponse")]
        ECMService.Manager.ServiceReference.EcmData[] GetDataByServiceId(int serviceId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConnectors/GetDataByServiceId", ReplyAction="http://tempuri.org/IConnectors/GetDataByServiceIdResponse")]
        System.Threading.Tasks.Task<ECMService.Manager.ServiceReference.EcmData[]> GetDataByServiceIdAsync(int serviceId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IConnectorsChannel : ECMService.Manager.ServiceReference.IConnectors, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ConnectorsClient : System.ServiceModel.ClientBase<ECMService.Manager.ServiceReference.IConnectors>, ECMService.Manager.ServiceReference.IConnectors {
        
        public ConnectorsClient() {
        }
        
        public ConnectorsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ConnectorsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConnectorsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConnectorsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int DoWork(int x, int y) {
            return base.Channel.DoWork(x, y);
        }
        
        public System.Threading.Tasks.Task<int> DoWorkAsync(int x, int y) {
            return base.Channel.DoWorkAsync(x, y);
        }
        
        public ECMService.Manager.ServiceReference.EcmData GetDataByEndPointId(int endPointId) {
            return base.Channel.GetDataByEndPointId(endPointId);
        }
        
        public System.Threading.Tasks.Task<ECMService.Manager.ServiceReference.EcmData> GetDataByEndPointIdAsync(int endPointId) {
            return base.Channel.GetDataByEndPointIdAsync(endPointId);
        }
        
        public ECMService.Manager.ServiceReference.EcmData[] GetDataByServiceId(int serviceId) {
            return base.Channel.GetDataByServiceId(serviceId);
        }
        
        public System.Threading.Tasks.Task<ECMService.Manager.ServiceReference.EcmData[]> GetDataByServiceIdAsync(int serviceId) {
            return base.Channel.GetDataByServiceIdAsync(serviceId);
        }
    }
}
