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

        public FakeRepository()
        {
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

        private List<ClientMetricDTO> GetMetrics()
        {
            return new List<ClientMetricDTO>()
            {
                new ClientMetricDTO(){ Id = 1, Name = "Метрика 1", MetricType = MonitorType.LanMonitor },
                new ClientMetricDTO(){ Id = 2, Name = "Метрика 2", MetricType = MonitorType.ResourceMonitor }
            };
        }

        public List<ClientMetricDTO> GetMetrics(int EndPointId)
        {
            return GetMetrics();

        }

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
                        Metrics = GetMetrics()
                    };
                    clientEndPointsByService.Add(ep);
                }
                clientEndPoints.Add(service.Id, clientEndPointsByService);
                endPointId = endPointId + clientEndPoints.Count;
            }
            return clientEndPoints;
        }

        #endregion
    }
}
