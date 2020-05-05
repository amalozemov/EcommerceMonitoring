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
        public IList<ClientEndPointDTO> GetEndPoints(int ServiceId)
        {
            var clientEndPoints = new List<ClientEndPointDTO>();
            for (int i = 0; i < 300; i++)
            {
                var ep = new ClientEndPointDTO()
                {
                    Id = i,
                    Ip = "192.168.0.100",
                    Port = 1800
                };
                clientEndPoints.Add(ep);
            }

            return clientEndPoints;
        }

        public IList<ClientServiceDTO> GetServices()
        {
            var clientServices = new List<ClientServiceDTO>()
            {
                new ClientServiceDTO()
                {
                    Id = 1,
                    Name = "Сервис 1"
                }
            };

            return clientServices;
        }
    }
}
