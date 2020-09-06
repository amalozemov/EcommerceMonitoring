using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Core.Exceptions
{
    public class DeviceAlreadyConnectedException : Exception
    {
        public DeviceAlreadyConnectedException(string message)
            : base(message)
        { }
    }
}
