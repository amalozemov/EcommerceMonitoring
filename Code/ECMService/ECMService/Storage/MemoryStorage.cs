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
        IDictionary<string, int> _httpStatusesCollection;
        object _syncObject;

        public MemoryStorage()
        {
            // все коллекции и их содержимое создаются при первой инициализации в методе AddEndoint и в дальнейшем их размеры не меняются.
            _devicesStatusesCollection = new Dictionary<string, LanDeviceStatus>();
            _httpStatusesCollection = new Dictionary<string, int>();
            _syncObject = new object();
        }

        public void Dispose()
        {
            lock (_syncObject)
            {
                _devicesStatusesCollection.Clear();
                _devicesStatusesCollection = null;
                _httpStatusesCollection.Clear();
                _httpStatusesCollection = null;
            }
        }

        public EcmData ExtractData(string ip, int port, int id)
        {
            var rez = default(EcmData);
            var key = $"{ip}:{port}-{id}";

            lock (_syncObject)
            {
                if (_devicesStatusesCollection != null && _httpStatusesCollection != null)
                {
                    rez = new EcmData(_devicesStatusesCollection[key], _httpStatusesCollection[key]);
                }
            }

            return rez;
        }

        public void WriteData(int id, string ip, int port, LanDeviceStatus deviceStatus)
        {
            var key = $"{ip}:{port}-{id}";

            lock (_syncObject)
            {
                //System.Threading.Thread.Sleep(1000);
                if (_devicesStatusesCollection != null)
                {
                    _devicesStatusesCollection[key] = deviceStatus;
                }
            }

        }

        public void WriteData(int id, string ip, int port, int httpErrorsCount)
        {
            var key = $"{ip}:{port}-{id}";

            lock (_syncObject)
            {
                if (_httpStatusesCollection != null)
                {
                    _httpStatusesCollection[key] = httpErrorsCount;
                }
            }
        }

        public void AddEndoint(string ip, int port, int id)
        {
            _devicesStatusesCollection.Add($"{ip}:{port}-{id}" , LanDeviceStatus.Sleep);
            _httpStatusesCollection.Add($"{ip}:{port}-{id}", 0);
        }
    }
}
