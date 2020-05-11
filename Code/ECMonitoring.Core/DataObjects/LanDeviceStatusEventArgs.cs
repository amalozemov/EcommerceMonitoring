using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Core
{
    public enum SourceEvent
    {
        Tcp,
        Http
    }
    public class LanDeviceStatusEventArgs : EventArgs
    {
        public SourceEvent EventSource { get; private set; }
        public int? HttpErrorsCount { get; private set; }
        public LanDeviceStatus? DeviceStatus { get; private set; }

        public LanDeviceStatusEventArgs(SourceEvent eventSource, LanDeviceStatus? deviceStatus, int? httpErrorsCount)
        {
            EventSource = eventSource;
            DeviceStatus = deviceStatus;
            HttpErrorsCount = httpErrorsCount;
        }
    }

}
