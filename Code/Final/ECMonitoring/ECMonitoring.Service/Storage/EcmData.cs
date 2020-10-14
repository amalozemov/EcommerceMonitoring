using ECMonitoring.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Service.Storage
{
    [DataContract]
    public class EcmData
    {
        [DataMember]
        public long EndPointId { get; private set; }
        [DataMember]
        public LanDeviceStatus? StatusLanDevice { get; private set; }
        [DataMember]
        public int? HttpErrorsCount { get; private set; }
        [DataMember]
        public double? MemoryUsage { get; private set; }
        [DataMember]
        public double? ProcessorTime { get; private set; }
        [DataMember]
        public int TypeMonitor { get; set; }
        [DataMember]
        public bool IsResourceRequestSuccess { get; set; }

        public EcmData(long endPointId, LanDeviceStatus? lanDeviceStatus, 
            int? httpErrorsCount, double? memoryUsage, double? processorTime,
            bool isResourceRequestSuccess)
        {
            EndPointId = endPointId;
            StatusLanDevice = lanDeviceStatus;
            HttpErrorsCount = httpErrorsCount;
            MemoryUsage = memoryUsage;
            ProcessorTime = processorTime;
            IsResourceRequestSuccess = isResourceRequestSuccess;
        }
    }
}
