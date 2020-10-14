using ECMonitoring.Manager.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Manager
{
    public class ECMManager : IDisposable
    {
        ECMServiceClient _clientService;
        IDictionary<long, DataContainer<EndPointDataDTO>> _endPointsCashe;
        IDictionary<long, DataContainer<ServiceDataDTO>> _servicesCashe;
        object _syncObject;
        int _periodDataUpdate;

        public ECMManager()
        {
            _clientService = new ECMServiceClient("BasicHttpBinding_IECMService");
            _endPointsCashe = new Dictionary<long, DataContainer<EndPointDataDTO>>();
            _servicesCashe = new Dictionary<long, DataContainer<ServiceDataDTO>>();
            _periodDataUpdate = 1000;
            _syncObject = new object();
        }

        public void Dispose()
        {
            try
            {
                _clientService.Close();
                _clientService = null;
                lock (_syncObject)
                {
                    _endPointsCashe.Clear();
                }
            }
            catch { }
        }

        /// <summary>
        /// Получение данных конечной точки.
        /// </summary>
        public EndPointDataDTO GetEndPointData(long endPointId)
        {
            lock (_syncObject)
            {
                if (_endPointsCashe.ContainsKey(endPointId))
                {
                    var dataCashe = _endPointsCashe[endPointId];
                    if (dataCashe?.TimeStamp >= DateTime.Now.AddMilliseconds(_periodDataUpdate))
                    {
                        return dataCashe.DataObject;
                    }
                }
                else
                {
                    _endPointsCashe.Add(endPointId, null);
                }

                var data = _clientService.GetDataByEndPointId(endPointId);
                if (data == null)
                {
                    return new EndPointDataDTO()
                    {
                        EndPointId = endPointId,
                        HttpErrorsCount = 0,
                        StatusLanDevice = LanDeviceStatus.Sleep,
                        MemoryUsage = 0,
                        ProcessorTime = 0
                    };
                }

                var endPointData = new EndPointDataDTO()
                {
                    EndPointId = data.EndPointId,
                    HttpErrorsCount = data.HttpErrorsCount,
                    StatusLanDevice = (LanDeviceStatus)data.StatusLanDevice,
                    MemoryUsage = data.MemoryUsage,
                    ProcessorTime = data.ProcessorTime,
                    IsResourceRequestSuccess = data.IsResourceRequestSuccess
                };

                var dataContainer = new DataContainer<EndPointDataDTO>()
                {
                    TimeStamp = DateTime.Now,
                    DataObject = endPointData
                };

                _endPointsCashe[endPointId] = dataContainer;

                return endPointData;
            }
        }

        /// <summary>
        /// Получение данных сервиса.
        /// </summary>
        public ServiceDataDTO GetServiceData(long serviceId)
        {
            lock (_syncObject)
            {
                var serviceData = new ServiceDataDTO()
                {
                    EndPointsData = new List<EndPointDataDTO>()
                };

                if (_servicesCashe.ContainsKey(serviceId))
                {
                    var dataCashe = _servicesCashe[serviceId];
                    if (dataCashe?.TimeStamp >= DateTime.Now.AddMilliseconds(_periodDataUpdate))
                    {
                        return dataCashe.DataObject;
                    }
                }
                else
                {
                    _servicesCashe.Add(serviceId, null);
                }

                var response = _clientService.GetDataByServiceId(serviceId);

                if (response == null)
                {
                    return serviceData;
                }

                foreach (var data in response)
                {
                    var endPointData = new EndPointDataDTO()
                    {
                        EndPointId = data.EndPointId,
                        HttpErrorsCount = data.HttpErrorsCount,
                        StatusLanDevice = (LanDeviceStatus?)data.StatusLanDevice,
                        MemoryUsage = data.MemoryUsage,
                        ProcessorTime = data.ProcessorTime,
                        TypeMonitor = (MetricType)data.TypeMonitor,
                        IsResourceRequestSuccess = data.IsResourceRequestSuccess
                    };
                    serviceData.EndPointsData.Add(endPointData);
                }

                var dataContainer = new DataContainer<ServiceDataDTO>()
                {
                    TimeStamp = DateTime.Now,
                    DataObject = serviceData
                };
                _servicesCashe[serviceId] = dataContainer;

                return serviceData;
            }
        }

        /// <summary>
        /// Сброс кол-ва ошибок http анализатора LAN монитора.
        /// </summary>
        public void HttpErrorsReset(long endPointId)
        {
            _clientService.HttpErrorsReset(endPointId);
        }
    }
}
