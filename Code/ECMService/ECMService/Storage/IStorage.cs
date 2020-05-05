using ECMonitoring.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMService.Storage
{
    internal interface IStorage
    {
        void WriteData(int id, string ip, int port, LanDeviceStatus deviceStatus);
        void WriteData(int id, string ip, int port, LanDeviceHttpStatus httpStatus);
        EcmData ExtractData(string ip, int port, int id); // добавить возвращаемый параметр для извлечения данных из хранилища (например при получении запроса из внешнего сервиса)
        void AddEndoint(string ip, int port, int id);
        void Dispose();
    }
}
