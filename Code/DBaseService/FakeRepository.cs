using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBaseService.DTO;

namespace DBaseService
{
    public class FakeRepository : IRepository
    {
        IList<ClientServiceDTO> _clientServices;
        IDictionary<int, IList<ClientEndPointDTO>> _clientEndPoints;
        IDictionary<int, List<ClientMetricDTO>> _endPointsMetrics;

        public FakeRepository()
        {
            _endPointsMetrics = new Dictionary<int, List<ClientMetricDTO>>();
            _clientServices = CreateServices();
            _clientEndPoints = CreateEndPoints(_clientServices);
        }

        public IList<ClientServiceDTO> GetServices()
        {
            return _clientServices;
        }

        public IList<ClientEndPointDTO> GetEndPoints(int ServiceId)
        {
            return _clientEndPoints[ServiceId];
        }

        public List<ClientMetricDTO> GetMetrics(int EndPointId)
        {
            //return new List<ClientMetricDTO>()
            //{
            //    new ClientMetricDTO(){ Id = $"{EndPointId}_1", Name = "Метрика 1", MetricType = MonitorType.LanMonitor },
            //    new ClientMetricDTO(){ Id = $"{EndPointId}_2", Name = "Метрика 2", MetricType = MonitorType.ResourceMonitor }
            //};
            return
                _endPointsMetrics[EndPointId];
        }

        //public List<ClientMetricDTO> GetMetrics(int EndPointId)
        //{
        //    return GetMetrics(EndPointId);

        //}

        public bool IsUserPresent(string userName, string password)
        {
            return true;
        }

        #region Создание фейковых объектов

        private IList<ClientServiceDTO> CreateServices()
        {
            var clientServices = new List<ClientServiceDTO>()
            {
                new ClientServiceDTO()
                {
                    Id = 1,
                    Name = "Сервис 1"
                },
                new ClientServiceDTO()
                {
                    Id = 2,
                    Name = "Сервис 2"
                },
                new ClientServiceDTO()
                {
                    Id = 3,
                    Name = "Сервис 3"
                },
                new ClientServiceDTO()
                {
                    Id = 4,
                    Name = "Сервис 4"
                },
                new ClientServiceDTO()
                {
                    Id = 5,
                    Name = "Сервис 5"
                },
                new ClientServiceDTO()
                {
                    Id = 6,
                    Name = "Сервис 6"
                },
                new ClientServiceDTO()
                {
                    Id = 7,
                    Name = "Сервис 7"
                },
                // если будут ошибки можно убрать
                new ClientServiceDTO()
                {
                    Id = 8,
                    Name = "Сервис 8"
                },
                new ClientServiceDTO()
                {
                    Id = 9,
                    Name = "Сервис 9"
                },
                new ClientServiceDTO()
                {
                    Id = 10,
                    Name = "Сервис 10"
                },
                new ClientServiceDTO()
                {
                    Id = 11,
                    Name = "Сервис 11"
                },
                new ClientServiceDTO()
                {
                    Id = 12,
                    Name = "Сервис 12"
                },
                new ClientServiceDTO()
                {
                    Id = 13,
                    Name = "Сервис 13"
                },
                new ClientServiceDTO()
                {
                    Id = 14,
                    Name = "Сервис 14"
                }
            };
            return clientServices;
        }

        private IDictionary<int, IList<ClientEndPointDTO>> CreateEndPoints(IList<ClientServiceDTO> clientServices)
        {
            
            var clientEndPoints = new Dictionary<int, IList<ClientEndPointDTO>>();
            //for (int i = 0; i < 300; i++)
            //for (int i = 0; i < 1; i++)
            //for (int i = 0; i < 10; i++)
            //for (int i = 0; i < 50; i++)
            //for (int i = 0; i < 50; i++)
            //{
            //    var ep = new ClientEndPointDTO()
            //    {
            //        Id = i,
            //        Ip = "192.168.0.101",
            //        Port = 1800,
            //        NetworkName = "NetworkName"
            //    };
            //    clientEndPoints.Add(ep);
            //}
            var endPointId = 0;
            foreach (var service in clientServices)
            {
                var clientEndPointsByService = new List<ClientEndPointDTO>();

                var endPointsCount = service.Id;
                for (int i = 0; i < endPointsCount; i++)
                {
                    var ep = new ClientEndPointDTO()
                    {
                        Id = endPointId + i + 1,
                        Ip = "192.168.0.101",
                        Port = 1800,
                        NetworkName = "NetworkName",
                        Name = $"Конечная точка с Id = {endPointId + i + 1}",
                        Metrics = i == endPointsCount - 1 ? CreateMetrics(endPointId + i + 1, MonitorType.ResourceMonitor) : CreateMetrics(endPointId + i + 1, MonitorType.LanMonitor)//GetMetrics(endPointId)
                    };
                    clientEndPointsByService.Add(ep);
                }
                clientEndPoints.Add(service.Id, clientEndPointsByService);
                endPointId = endPointId + clientEndPoints.Count;
            }
            return clientEndPoints;
        }

        private List<ClientMetricDTO> CreateMetrics(int endPointId, MonitorType monitorType)
        {

            //    new ClientMetricDTO(){ Id = $"{EndPointId}_1", Name = "Метрика 1", MetricType = MonitorType.LanMonitor },
            //    new ClientMetricDTO(){ Id = $"{EndPointId}_2", Name = "Метрика 2", MetricType = MonitorType.ResourceMonitor }
            //};

            var metric = default(ClientMetricDTO);
            if (monitorType == MonitorType.LanMonitor)
            {
                metric = new ClientMetricDTO() { Id = $"{endPointId}_1", Name = $"Метрика сетевой монитор {endPointId}", MetricType = MonitorType.LanMonitor };
            }
            else
            {
                metric = new ClientMetricDTO() { Id = $"{endPointId}_2", Name = $"Монитор ресурсов {endPointId}", MetricType = MonitorType.ResourceMonitor };
            }

            var metrics = new List<ClientMetricDTO>() { metric };
            _endPointsMetrics.Add(endPointId, metrics);

            return metrics;
        }

        #endregion
    }
}
