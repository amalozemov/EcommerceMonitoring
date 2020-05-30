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
        public LanDeviceStatus? StatusLanDevice { get; private set; }
        [DataMember]
        public int? HttpErrorsCount { get; private set; }

        public EcmData(LanDeviceStatus? lanDeviceStatus, int? httpErrorsCount)
        {
            StatusLanDevice = lanDeviceStatus;
            HttpErrorsCount = httpErrorsCount;
        }
    }
}
