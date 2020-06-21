using ECMonitoring.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ECMService.Storage
{
    [DataContract]
    public class EcmData
    {
        [DataMember]
        public int EndPointId { get; private set; }
        [DataMember]
        public LanDeviceStatus? StatusLanDevice { get; private set; }
        [DataMember]
        public int? HttpErrorsCount { get; private set; }
        [DataMember]
        public int? MemoryUsage { get; private set; }
        [DataMember]
        public int? ProcessorTime { get; private set; }

        public EcmData(int endPointId, LanDeviceStatus? lanDeviceStatus, int? httpErrorsCount, int? memoryUsage, int? processorTime)
        {
            EndPointId = endPointId;
            StatusLanDevice = lanDeviceStatus;
            HttpErrorsCount = httpErrorsCount;
            MemoryUsage = memoryUsage;
            ProcessorTime = processorTime;
        }
    }
}
