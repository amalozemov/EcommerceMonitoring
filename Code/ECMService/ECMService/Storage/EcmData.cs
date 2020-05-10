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
        public int HttpErrorsCount { get; private set; }

        public EcmData(LanDeviceStatus lanDeviceStatus, int httpErrorsCount)
        {
            StatusLanDevice = lanDeviceStatus;
            HttpErrorsCount = httpErrorsCount;
        }
    }
}
