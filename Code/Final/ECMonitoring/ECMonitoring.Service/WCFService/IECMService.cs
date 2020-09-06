using ECMonitoring.Service.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Service
{
    //https://www.youtube.com/watch?v=KY1w9nwRL5I&list=PL-ss7IpVOiB7zD2KpSoaKev4Yb4NByuk-&index=2 - про WCF
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IConnectors" в коде и файле конфигурации.
    [ServiceContract]
    public interface IECMService
    {
        [OperationContract]
        int DoWork(int x, int y);

        [OperationContract]
        EcmData GetDataByEndPointId(long endPointId);

        [OperationContract]
        IList<EcmData> GetDataByServiceId(long serviceId);

        [OperationContract]
        void HttpErrorsReset(long EndPointId);
    }
}
