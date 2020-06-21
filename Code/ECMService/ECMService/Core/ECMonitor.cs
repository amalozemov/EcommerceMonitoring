using DBaseService;
using ECMService.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMService.Core
{
    internal enum MonitorType
    {
        LanMonitor = 0,
        ResourceMonitor = 1
    }

    internal static class ECMonitor
    {
        static IList<ClientEndPoint> _clientEndPoints;
        static IRepository _repository;
        static IStorage _storage;
        static object _syncObject;
        public static bool IsConnected { get; private set; }


        static ECMonitor()
        {
            _clientEndPoints = new List<ClientEndPoint>();
            _repository = new FakeRepository();
            _syncObject = new object();
        }

        public static void Start()
        {
            lock (_syncObject)
            {
                if (IsConnected)
                {
                    return;
                }

                _storage = new MemoryStorage();

                var datas = _repository.GetServices();
                foreach (var service in datas)
                {
                    var endpoints = _repository.GetEndPoints(service.Id);
                    foreach (var endpoint in endpoints)
                    {
                        var ep = new ClientEndPoint(_repository, endpoint.Ip, endpoint.Port, endpoint.Id, endpoint.NetworkName, _storage);
                        _storage.AddEndoint(ep);
                        _clientEndPoints.Add(ep);
                        ep.Start();
                    }
                }

                IsConnected = true;
            }
        }

        public static void Stop()
        {
            lock (_syncObject)
            {
                if (!IsConnected)
                {
                    return;
                }

                IsConnected = false;

                foreach (var ep in _clientEndPoints)
                {
                    ep.Stop();
                }
                _clientEndPoints.Clear();
                _storage.Dispose();
            }
        }

        public static EcmData GetDataByEndPointId(int endPointid)
        {
            lock (_syncObject)
            {
                if (!IsConnected)
                {
                    return null;
                }
                var data = _storage.ExtractData(endPointid);
                return data;
            }
        }

        /// <summary>
        /// Данные по конечным точкам сервиса можно получить не меняя сруктуру приложения, 
        /// для этого нужно получить из БД все конечные точки сервиса и получить данные для них.
        /// </summary>
        public static IList<EcmData> GetDataByServiceId(int serviceId)
        {
            lock (_syncObject)
            {
                if (!IsConnected)
                {
                    return null;
                }

                IList<EcmData> result = new List<EcmData>();
                var endPoints = _repository.GetEndPoints(serviceId);
                foreach (var ep in endPoints)
                {
                    var data = _storage.ExtractData(ep.Id);
                    result.Add(data);
                }
                return result;
            }
        }

        public static void HttpErrorsReset(int id)
        {
        }
    }
}
