using ECMonitoring.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMService.Storage
{
    public class EcmData
    {
        public LanDeviceStatus StatusLanDevice { get; private set; }
        public LanDeviceHttpStatus StatusLanDeviceHttp { get; private set; }

        public EcmData(LanDeviceStatus lanDeviceStatus, LanDeviceHttpStatus lanDeviceHttpStatus)
        {
            StatusLanDevice = lanDeviceStatus;
            StatusLanDeviceHttp = lanDeviceHttpStatus;
        }
    }
}
