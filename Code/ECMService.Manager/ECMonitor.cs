using ECMService.Manager.DTO;
using ECMService.Manager.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMService.Manager
{
    //public enum ResultOperation
    //{
    //    NoChange,
    //    Success
    //}

    public class ECMonitor : IDisposable
    {
        ConnectorsClient _clientService;
        //IDictionary<int, EndPointDataDTO> _endPointsCashe;
        IDictionary<int, DataContainer<EndPointDataDTO>> _endPointsCashe;
        IDictionary<int, DataContainer<ServiceDataDTO>> _servicesCashe;
        object _syncObject;
        int _periodDataUpdate;

        public ECMonitor()
        {
            _clientService = new ConnectorsClient("BasicHttpBinding_IConnectors");
            _endPointsCashe = new Dictionary<int, DataContainer<EndPointDataDTO>>();
            _servicesCashe = new Dictionary<int, DataContainer<ServiceDataDTO>>();
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

        //public ResultOperation GetDataByEndPointId(int endPointId, out EndPointDataDTO endPointData)
        //{
        //    var res = ResultOperation.Success;
        //    var data = _clientService.GetDataByEndPointId(endPointId);
        //    endPointData = new EndPointDataDTO()
        //    {
        //        HttpErrorsCount = data.HttpErrorsCount,
        //        StatusLanDevice = (LanDeviceStatus)data.StatusLanDevice,
        //    };

        //    lock (_syncObject)
        //    {
        //        if (!_endPointsCashe.ContainsKey(endPointId))
        //        {
        //            _endPointsCashe.Add(endPointId, endPointData);
        //        }
        //        else
        //        {
        //            var prvEndPointData = _endPointsCashe[endPointId];
        //            if (endPointData.Equals(prvEndPointData))
        //            {
        //                return ResultOperation.NoChange;
        //            }
        //            else
        //            {
        //                _endPointsCashe[endPointId] = endPointData;
        //            }
        //        }
        //    }

        //    // тут 07.06.2020 делать универсальную коллекцию (словарь) для хранения данных разного типа с временем записи их в коллекцию как класс DataContainer
        //    // или делать две коллекции 1 - для конечных точкек 2 - для сервисов и переменная содержащая коллекцию всех данных.

        //    // решение коллекции 2 - словарь вида Dictionary<int,  DataContainer<EndPointDataDTO>>, вторая Dictionary<int,  DataContainer<ServiceDataDTO>>
        //    // ипеременная типа DataContainer<ECMonitorDataDTO>

        //    var t = new DataContainer<EndPointDataDTO>();

        //    var t1 = t.DataObject;


        //    return res;
        //}

        /// <summary>
        /// Получение данных конечной точки.
        /// </summary>
        public EndPointDataDTO GetEndPointData(int endPointId)
        {
            lock (_syncObject)
            {
                if (_endPointsCashe.ContainsKey(endPointId))
                {
                    var dataCashe = _endPointsCashe[endPointId];
                    if (dataCashe.TimeStamp >= DateTime.Now.AddMilliseconds(_periodDataUpdate))
                    {
                        return dataCashe.DataObject;
                    }
                }
                else
                {
                    _endPointsCashe.Add(endPointId, null);
                }

                var data = _clientService.GetDataByEndPointId(endPointId);
                var endPointData = new EndPointDataDTO()
                {
                    EndPointId = data.EndPointId,
                    HttpErrorsCount = data.HttpErrorsCount,
                    StatusLanDevice = (LanDeviceStatus)data.StatusLanDevice,
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
        public ServiceDataDTO GetServiceData(int serviceId)
        {
            lock (_syncObject)
            {
                if (_servicesCashe.ContainsKey(serviceId))
                {
                    var dataCashe = _servicesCashe[serviceId];
                    if (dataCashe.TimeStamp >= DateTime.Now.AddMilliseconds(_periodDataUpdate))
                    {
                        return dataCashe.DataObject;
                    }
                }
                else
                {
                    _servicesCashe.Add(serviceId, null);
                }

                var response = _clientService.GetDataByServiceId(serviceId);
                var serviceData = new ServiceDataDTO()
                {
                    EndPointsData = new List<EndPointDataDTO>()
                };
                foreach (var data in response)
                {
                    var endPointData = new EndPointDataDTO()
                    {
                        EndPointId = data.EndPointId,
                        HttpErrorsCount = data.HttpErrorsCount,
                        StatusLanDevice = (LanDeviceStatus)data.StatusLanDevice,
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
    }
}
