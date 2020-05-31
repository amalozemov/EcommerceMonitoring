using ECMService.Manager.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMService.Manager
{
    public enum ResultOperation
    {
        NoChange,
        Success
    }

    public class ECMonitor : IDisposable
    {
        ConnectorsClient _clientService;

        public ECMonitor()
        {
            _clientService = new ConnectorsClient("BasicHttpBinding_IConnectors");// "BasicHttpBinding_IConnectors");
            
        }

        public void Dispose()
        {
            _clientService.Close();
            _clientService = null;
        }

        public ResultOperation GetDataByEndPointId(int endPointId, out EndPointDataDTO endPointData)
        {
            var res = ResultOperation.Success;
            var data = _clientService.GetDataByEndPointId(endPointId);

            endPointData = new EndPointDataDTO()
            {
                HttpErrorsCount = data.HttpErrorsCount,
                StatusLanDevice = (LanDeviceStatus)data.StatusLanDevice,
            };
            return res;
        }
    }
}
