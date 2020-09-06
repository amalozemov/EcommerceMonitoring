using ECMonitoring.Data;
using ECMonitoring.Data.Fake;
using ECMonitoring.Service.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Service.Core
{
    internal enum MonitorType
    {
        LanMonitor = 0,
        ResourceMonitor = 1
    }

    internal class Dispatcher
    {
        IUnitOfWorkFactory _unitOfWorkFactory;
        IList<ECMonitor> _monitors;
        IStorage _storage;
        object _syncObject;
        public bool IsConnected { get; private set; }

        internal Dispatcher()
        {
            var connectionString = 
                ConfigurationManager.ConnectionStrings["ECMonitoring"].ConnectionString;
            _unitOfWorkFactory = new FakeUnitOfWorkFactory(connectionString);
            _monitors = new List<ECMonitor>();
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

                //var datas = _repository.GetServices();
                //foreach (var service in datas)
                //{
                //    var endpoints = _repository.GetEndPoints(service.Id);
                //    foreach (var endpoint in endpoints)
                //    {
                //        //var ep = new ClientEndPoint(_repository, endpoint.Ip, endpoint.Port, endpoint.Id, endpoint.NetworkName, _storage);
                //        var ep = new ECMonitor(endpoint, _storage);
                //        _storage.AddEndoint(ep);
                //        _clientEndPoints.Add(ep);
                //        ep.Start();
                //    }
                //}

                using (var uow = _unitOfWorkFactory.Create())
                {
                    var repository = uow.GetRepository();
                    var services = 
                        repository.GetEntities<Data.Service>();

                    foreach (var service in services)
                    {
                        var endpoints = 
                            repository.GetEntities<EndPoint>().Where(p => p.ServiceId == service.Id);//.GetEndPoints(service.Id);
                        foreach (var endpoint in endpoints)
                        {
                            var ecm = new ECMonitor(endpoint, _storage);
                            _storage.AddEndoint(ecm);
                            _monitors.Add(ecm);
                            ecm.Start();
                        }
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

                foreach (var m in _monitors)
                {
                    m.Stop();
                }
                _monitors.Clear();
                _storage.Dispose();
            }
        }

        public EcmData GetDataByEndPointId(long endPointid)
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
        /// для этого нужно получить из БД все конечные точки сервиса и получить данные по ним.
        /// </summary>
        public IList<EcmData> GetDataByServiceId(long serviceId)
        {
            lock (_syncObject)
            {
                if (!IsConnected)
                {
                    return null;
                }

                var result = new List<EcmData>();
                var endPoints = _monitors.Where(p => p.ServiceId == serviceId);// _repository.GetEndPoints(serviceId);
                foreach (var ep in endPoints)
                {
                    var data = _storage.ExtractData(ep.Id);
                    data.TypeMonitor = (int)ep.TypeMonitor;
                    result.Add(data);
                }
                return result;
            }
        }

        /// <summary>
        /// Сброс кол-ва ошибок http анализатора.
        /// </summary>
        public void HttpErrorsReset(long endPointId)
        {
            var monitor = _monitors.Where(e => e.Id == endPointId).FirstOrDefault();
            monitor.HttpErrorsReset();
        }

        public int GetEndPointsCount()
        {
            return _monitors.Count;
        }
    }
}
