using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMService.Manager
{
    public enum LanDeviceStatus
    {
        Sleep = 0,
        Connect = 1,
        Disconnect = 2,
        Break = 3,
    }

    public class EndPointDataDTO
    {
        public int? HttpErrorsCount { get; internal set; }
        public LanDeviceStatus? StatusLanDevice { get; internal set; }
    }
}
