using ECMonitoring.Core;
using ECMService.Core;
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
        IDictionary<int, int> _httpErrorsCountCollection;
        object _syncObject;

        public MemoryStorage()
        {
            // все коллекции и их содержимое создаются при первой инициализации в методе 
            // AddEndoint и в дальнейшем их размеры не меняются.
            _devicesStatusesCollection = new Dictionary<int, LanDeviceStatus>();
            _httpErrorsCountCollection = new Dictionary<int, int>();
            _syncObject = new object();
        }

        public void Dispose()
        {
            lock (_syncObject)
            {
                _devicesStatusesCollection.Clear();
                _devicesStatusesCollection = null;
                _httpErrorsCountCollection.Clear();
                _httpErrorsCountCollection = null;
            }
        }

        public EcmData ExtractData(int id)
        {
            var rez = default(EcmData);

            lock (_syncObject)
            {
                if (_devicesStatusesCollection != null && _httpErrorsCountCollection != null)
                {
                    var devicesStatus = _devicesStatusesCollection.Keys.Contains(id) ? (LanDeviceStatus?)_devicesStatusesCollection[id] : null;
                    var httpErrorsCount = _httpErrorsCountCollection.Keys.Contains(id) ? (int?)_httpErrorsCountCollection[id] : null;
                    rez = new EcmData(id, devicesStatus, httpErrorsCount);
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
                if (_httpErrorsCountCollection != null)
                {
                    _httpErrorsCountCollection[id] = httpErrorsCount;
                }
            }
        }

        public void AddEndoint(ClientEndPoint endPoint)
        {
            foreach (var m in endPoint.Metrics)
            {
                switch (m)
                {
                    case MonitorType.LanMonitor:
                        _devicesStatusesCollection.Add(endPoint.Id, LanDeviceStatus.Sleep);
                        _httpErrorsCountCollection.Add(endPoint.Id, 0);
                        break;
                    default:
                        throw new NotImplementedException("Метрика не реализована.");
                }
            }
        }
    }
}
