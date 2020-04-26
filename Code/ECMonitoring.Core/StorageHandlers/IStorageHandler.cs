using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Core
{
    internal interface IStorageHandler
    {
        void WriteData(DeviceStatus deviceStatus);
        void WriteData(HttpDeviceResponseStatus httpStatus); 
        void ExtractData(); // добавить возвращаемый параметр для извлечения данных из хранилища (например при получении запроса из внешнего сервиса)
    }
}
