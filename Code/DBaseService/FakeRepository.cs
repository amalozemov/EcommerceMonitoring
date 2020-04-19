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
            var clientEndPoints = new List<ClientEndPointDTO>()
            {
                new ClientEndPointDTO()
                {
                    Id = 1,
                    Ip = "192.168.0.100",
                    Port = 1800
                }
            };

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
