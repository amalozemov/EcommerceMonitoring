using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Core
{
    internal class MemoryStorage : IStorageHandler
    {
        DeviceStatus _deviceStatus;
        IList<HttpDeviceResponseStatus> _httpStatusesCollection;

        public MemoryStorage()
        {
            _httpStatusesCollection = new List<HttpDeviceResponseStatus>();
        }

        public void ExtractData()
        {
            throw new NotImplementedException();
        }

        public void WriteData(DeviceStatus deviceStatus)
        {
            _deviceStatus = deviceStatus;
        }

        public void WriteData(HttpDeviceResponseStatus httpStatus)
        {
            _httpStatusesCollection.Add(httpStatus);
        }
    }
}
