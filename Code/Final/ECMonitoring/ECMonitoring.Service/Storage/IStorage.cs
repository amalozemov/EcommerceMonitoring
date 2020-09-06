using ECMonitoring.Core;
using ECMonitoring.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Service.Storage
{
    internal interface IStorage
    {
        void WriteData(long id, LanDeviceStatus deviceStatus);
        void WriteData(long id, int httpErrorsCount);
        void WriteData(long id, ResourceUsage resourceUsage);
        EcmData ExtractData(long id);
        void AddEndoint(ECMonitor endPoint);
        void Dispose();
    }
}
