using DBaseService;
using ECMService.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMService.Core
{
    internal class ECMonitor
    {
        IList<ClientEndPoint> _clientEndPoints;
        IRepository _repository;
        IStorage _storage;
        object _syncObject;
        public bool IsConnected { get; private set; }


        public ECMonitor()
        {
            _clientEndPoints = new List<ClientEndPoint>();
            _repository = new FakeRepository();
            _syncObject = new object();
        }

        public void Start()
        {
            lock (_syncObject)
            {
                if (IsConnected)
                {
                    return;
                }

                _storage = new MemoryStorage();

                var datas = _repository.GetServices();
                foreach (var services in datas)
                {
                    var endpoints = _repository.GetEndPoints(services.Id);
                    foreach (var endpoint in endpoints)
                    {
                        var ep = new ClientEndPoint(_repository, endpoint.Ip, endpoint.Port, endpoint.Id, _storage);
                        _storage.AddEndoint(ep.Id);
                        _clientEndPoints.Add(ep);
                        ep.Start();
                    }
                }

                IsConnected = true;
            }
        }

        public void Stop()
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

        public EcmData GetDataByEndPointId(int endPointid)
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
        public EcmData GetDataByServiceId(int serviceid)
        {
            throw new NotImplementedException("Метод GetDataByServiceId не реализован.");
        }

        public void HttpErrorsReset(int id)
        {
        }
    }
}
