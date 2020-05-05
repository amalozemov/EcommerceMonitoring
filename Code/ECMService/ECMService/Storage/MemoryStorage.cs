using ECMonitoring.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMService.Storage
{
    internal class MemoryStorage : IStorage
    {
        IDictionary<string, LanDeviceStatus> _devicesStatusesCollection;
        IDictionary<string, LanDeviceHttpStatus> _httpStatusesCollection;
        object _syncObject;

        public MemoryStorage()
        {
            // все коллекции и их содержимое создаются при первой инициализации в методе AddEndoint и в дальнейшем их размеры не меняются.
            _devicesStatusesCollection = new Dictionary<string, LanDeviceStatus>();
            _httpStatusesCollection = new Dictionary<string, LanDeviceHttpStatus>();
            _syncObject = new object();
        }

        public void Dispose()
        {
            _devicesStatusesCollection.Clear();
            _devicesStatusesCollection = null;
            _httpStatusesCollection.Clear();
            _httpStatusesCollection = null;
        }

        public void ExtractData()
        {
            lock (_syncObject)
            {
                throw new NotImplementedException();
            }
        }

        public void WriteData(int id, string ip, int port, LanDeviceStatus deviceStatus)
        {
            lock (_syncObject)
            {
                _devicesStatusesCollection[ip] = deviceStatus;
            }

        }

        public void WriteData(int id, string ip, int port, LanDeviceHttpStatus httpStatus)
        {
            lock (_syncObject)
            {
                _httpStatusesCollection[ip] = httpStatus;
            }
        }

        public void AddEndoint(string ip)
        {
            _devicesStatusesCollection.Add(ip, new LanDeviceStatus());
            _httpStatusesCollection.Add(ip, new LanDeviceHttpStatus());
        }
    }
}
