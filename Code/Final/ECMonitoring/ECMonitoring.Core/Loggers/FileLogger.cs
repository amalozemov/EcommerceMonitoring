using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Core
{
    internal class FileLogger : ILogger
    {
        public void HttpLog(LanDeviceHttpStatus httpStatus)
        {
            Console.WriteLine($"{httpStatus.StatusCode} --- {httpStatus.ErrorDescription}");
        }

        public void StartApplication()
        {
            throw new NotImplementedException();
        }

        public void StopApplication()
        {
            throw new NotImplementedException();
        }

        public void TcpLog(LanDeviceStatus deviceStatus)
        {
            Console.WriteLine(deviceStatus);
        }
    }
}
