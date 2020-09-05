using ECMService.Core;
using ECMService.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ECMService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Connectors" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Connectors : IConnectors
    {
        Dispatcher _dispatcher;

        internal Connectors(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public int DoWork(int x, int y)
        {
            return x + y;
        }

        public EcmData GetDataByEndPointId(int endPointId)
        {
            var data = _dispatcher.GetDataByEndPointId(endPointId);
            return data;
        }

        public IList<EcmData> GetDataByServiceId(int serviceId)
        {
            var data = _dispatcher.GetDataByServiceId(serviceId);
            return data;
        }

        public void HttpErrorsReset(int EndPointId)
        {
            _dispatcher.HttpErrorsReset(EndPointId);
        }
    }
}
