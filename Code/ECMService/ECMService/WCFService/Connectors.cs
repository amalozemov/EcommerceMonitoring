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
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Connectors : IConnectors
    {
        //ECMonitor _ecMonitor;

        //internal Connectors(ECMonitor ecMonitor)
        //{
        //    _ecMonitor = ecMonitor;
        //}

        public int DoWork(int x, int y)
        {
            return x + y;
        }

        public EcmData GetDataByEndPointId(int endPointid)
        {
            var data = ECMonitor.GetDataByEndPointId(endPointid);
            return data;
        }
    }
}
