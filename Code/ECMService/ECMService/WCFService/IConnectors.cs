using ECMService.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ECMService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IConnectors" в коде и файле конфигурации.
    [ServiceContract]
    public interface IConnectors
    {
        [OperationContract]
        int DoWork(int x, int y);

        [OperationContract]
        EcmData GetDataByEndPointId(int endPointid);
    }
}
