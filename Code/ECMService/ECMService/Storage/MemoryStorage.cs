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
        IDictionary<int, LanDeviceStatus> _devicesStatusesCollection;
        IDictionary<int, int> _httpStatusesCollection;
        object _syncObject;

        public MemoryStorage()
        {
            // все коллекции и их содержимое создаются при первой инициализации в методе 
            // AddEndoint и в дальнейшем их размеры не меняются.
            _devicesStatusesCollection = new Dictionary<int, LanDeviceStatus>();
            _httpStatusesCollection = new Dictionary<int, int>();
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

        public EcmData ExtractData(int id)
        {
            var rez = default(EcmData);

            lock (_syncObject)
            {
                if (_devicesStatusesCollection != null && _httpStatusesCollection != null)
                {
                    rez = new EcmData(_devicesStatusesCollection[id], _httpStatusesCollection[id]);
                }
            }

            return rez;
        }

        public void WriteData(int id, LanDeviceStatus deviceStatus)
        {
            lock (_syncObject)
            {
                if (_devicesStatusesCollection != null)
                {
                    _devicesStatusesCollection[id] = deviceStatus;
                }
            }

        }

        public void WriteData(int id, int httpErrorsCount)
        {
            lock (_syncObject)
            {
                if (_httpStatusesCollection != null)
                {
                    _httpStatusesCollection[id] = httpErrorsCount;
                }
            }
        }

        public void AddEndoint(int id)
        {
            _devicesStatusesCollection.Add(id, LanDeviceStatus.Sleep);
            _httpStatusesCollection.Add(id, 0);
        }
    }
}
