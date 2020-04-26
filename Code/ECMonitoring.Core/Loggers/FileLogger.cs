using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Core
{
    internal class FileLogger : ILogger
    {
        public void HttpLog(HttpDeviceResponseStatus httpStatus)
        {
            throw new NotImplementedException();
        }

        public void StartApplication()
        {
            throw new NotImplementedException();
        }

        public void StopApplication()
        {
            throw new NotImplementedException();
        }

        public void TcpLog(DeviceStatus deviceStatus)
        {
            Console.WriteLine(deviceStatus);
        }
    }
}
