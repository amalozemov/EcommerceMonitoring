using ECMonitoring.Core;
using ECMService.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMService.Storage
{
    internal interface IStorage
    {
        void WriteData(int id, LanDeviceStatus deviceStatus);
        void WriteData(int id, int httpErrorsCount);
        void WriteData(int id, ResourceUsage resourceUsage);
        EcmData ExtractData(int id);
        void AddEndoint(ClientEndPoint endPoint);
        void Dispose();
    }
}
