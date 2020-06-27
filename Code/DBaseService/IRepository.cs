using DBaseService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBaseService
{
    public interface IRepository
    {
        IList<ClientServiceDTO> GetServices();
        IList<ClientEndPointDTO> GetEndPoints(int ServiceId);
        int[] GetMetrics(int id);
        bool IsUserPresent(string userName, string password);
    }
}
