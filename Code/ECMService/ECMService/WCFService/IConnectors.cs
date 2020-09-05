using ECMService.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ECMService
{
    //https://www.youtube.com/watch?v=KY1w9nwRL5I&list=PL-ss7IpVOiB7zD2KpSoaKev4Yb4NByuk-&index=2 - про WCF
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IConnectors" в коде и файле конфигурации.
    [ServiceContract]
    //[ServiceContract(SessionMode = SessionMode.Required)]
    public interface IConnectors
    {
        [OperationContract]
        int DoWork(int x, int y);

        [OperationContract]
        EcmData GetDataByEndPointId(int endPointId);

        [OperationContract]
        IList<EcmData> GetDataByServiceId(int serviceId);

        [OperationContract]
        void HttpErrorsReset(int EndPointId);
    }
}
