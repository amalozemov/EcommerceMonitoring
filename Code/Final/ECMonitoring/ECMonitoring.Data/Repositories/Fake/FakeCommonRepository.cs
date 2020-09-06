using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Data.Fake
{
    internal class FakeCommonRepository : ICommonRepository
    {
        IList<Service> _clientServices;
        IList<EndPoint> _clientEndPoints;
        IList<User> _users;

        public FakeCommonRepository() 
        {
            _clientServices = CreateServices();
            _clientEndPoints = CreateEndPoints(_clientServices);
            _users = CreateUsers();
        }

        public void Add<T>(T entity) where T : Entity
        {
            
        }

        public void Delete<T>(T entity) where T : Entity
        {
            
        }

        public T FindById<T>(long id) where T : Entity
        {
            if (typeof(T) == typeof(Service))
            {
                return _clientServices.Where(p => p.Id == id).FirstOrDefault() as T; 
            }
            else if (typeof(T) == typeof(EndPoint))
            {
                return _clientEndPoints.Where(p => p.Id == id).FirstOrDefault() as T;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<T> GetEntities<T>() where T : Entity
        {
            if (typeof(T) == typeof(Service))
            {
                return _clientServices.Select(p => p as T);
            }
            else if (typeof(T) == typeof(EndPoint))
            {
                return _clientEndPoints.Select(p => p as T);
            }
            else if (typeof(T) == typeof(User))
            {
                return _users.Select(p => p as T);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<T> GetEntities<T>(Expression<Func<T, bool>> expr, bool includeInactive = false) where T : Entity
        {
            throw new NotImplementedException();
        }

        public T GetEntity<T>(Expression<Func<T, bool>> expr, bool includeInactive = false) where T : Entity
        {
            throw new NotImplementedException();
        }

        #region Создание фейковых объектов

        private IList<Service> CreateServices()
        {
            var clientServices = new List<Service>()
            {
                new Service()
                {
                    Id = 1,
                    Name = "Сервис 1"
                },
                new Service()
                {
                    Id = 2,
                    Name = "Сервис 2"
                },
                new Service()
                {
                    Id = 3,
                    Name = "Сервис 3"
                },
                new Service()
                {
                    Id = 4,
                    Name = "Сервис 4"
                },
                new Service()
                {
                    Id = 5,
                    Name = "Сервис 5"
                },
                new Service()
                {
                    Id = 6,
                    Name = "Сервис 6"
                },
                new Service()
                {
                    Id = 7,
                    Name = "Сервис 7"
                },
                // если будут ошибки можно убрать
                new Service()
                {
                    Id = 8,
                    Name = "Сервис 8"
                },
                new Service()
                {
                    Id = 9,
                    Name = "Сервис 9"
                },
                new Service()
                {
                    Id = 10,
                    Name = "Сервис 10"
                },
                new Service()
                {
                    Id = 11,
                    Name = "Сервис 11"
                },
                new Service()
                {
                    Id = 12,
                    Name = "Сервис 12"
                },
                new Service()
                {
                    Id = 13,
                    Name = "Сервис 13"
                },
                new Service()
                {
                    Id = 14,
                    Name = "Сервис 14"
                }
            };
            return clientServices;
        }

        private IList<EndPoint> CreateEndPoints(IList<Service> clientServices)
        {
            var clientEndPoints = new List<EndPoint>();
            
            var endPointId = 0;
            foreach (var service in clientServices)
            {
                //var clientEndPointsByService = new List<EndPoint>();

                var endPointsCount = service.Id;
                for (int i = 0; i < endPointsCount; i++)
                {
                    var ep = new EndPoint()
                    {
                        ServiceId = service.Id,
                        Id = endPointId + i + 1,
                        Ip = "192.168.0.101",
                        Port = 1800,
                        NetworkName = "NetworkName",
                        Name = $"Конечная точка с Id = {endPointId + i + 1}",
                        //Metrics = (i == endPointsCount - 1) && (i != 0)  ? CreateMetrics(endPointId + i + 1, MonitorType.ResourceMonitor) : CreateMetrics(endPointId + i + 1, MonitorType.LanMonitor)//GetMetrics(endPointId)
                        //TypeMonitor = (i == endPointsCount - 1) && (i != 0) ? MonitorType.ResourceMonitor : MonitorType.LanMonitor
                        Service = service,
                        EndPointType = (i == endPointsCount - 1) && (i != 0) ? new EndPointType() { Value = TypeEndPoint.ResourceMonitor } : new EndPointType() { Value = TypeEndPoint.LanMonitor }
                    };
                    //clientEndPointsByService.Add(ep);
                    clientEndPoints.Add(ep);
                }
                //clientEndPoints.Add(clientEndPointsByService);
                endPointId = endPointId + clientEndPoints.Count;
            }
            return clientEndPoints;
        }


        private IList<User> CreateUsers()
        {
            _users = new List<User>();
            _users.Add(new User()
            {
                Id = 1,
                Login = "1",
                Password="1"
            });
            return _users;
        }
        #endregion
    }
}
