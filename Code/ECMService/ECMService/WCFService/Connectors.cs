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
    public class Connectors : IConnectors
    {
        public int DoWork(int x, int y)
        {
            return x + y;
        }

        public EcmData GetDataByEndPointId(int endPointId)
        {
            var data = ECMonitor.GetDataByEndPointId(endPointId);
            return data;
        }

        public IList<EcmData> GetDataByServiceId(int serviceId)
        {
            var data = ECMonitor.GetDataByServiceId(serviceId);
            return data;
        }

        public void HttpErrorsReset(int EndPointId)
        {
            ECMonitor.HttpErrorsReset(EndPointId);
        }
    }
}
