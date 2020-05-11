using ECMonitoring.Core;
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
        EcmData ExtractData(int id);
        void AddEndoint(int id);
        void Dispose();
    }
}
