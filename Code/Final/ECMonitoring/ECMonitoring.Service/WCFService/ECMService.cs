using ECMonitoring.Service.Core;
using ECMonitoring.Service.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Service
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Connectors" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ECMService : IECMService
    {
        Dispatcher _dispatcher;

        internal ECMService(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public int DoWork(int x, int y)
        {
            return x + y;
        }

        public EcmData GetDataByEndPointId(long endPointId)
        {
            var data = _dispatcher.GetDataByEndPointId(endPointId);
            return data;
        }

        public IList<EcmData> GetDataByServiceId(long serviceId)
        {
            var data = _dispatcher.GetDataByServiceId(serviceId);
            return data;
        }

        public void HttpErrorsReset(long EndPointId)
        {
            _dispatcher.HttpErrorsReset(EndPointId);
        }
    }
}
