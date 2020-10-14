using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Manager
{
    public enum LanDeviceStatus
    {
        Sleep = 0,
        Connect = 1,
        Disconnect = 2,
        Break = 3,
    }

    public enum MetricType
    {
        LanMonitor = 0,
        ResourceMonitor = 1
    }

    public class EndPointDataDTO //: IEquatable<EndPointDataDTO>
    {
        public long EndPointId { get; internal set; }
        public int? HttpErrorsCount { get; internal set; }
        public LanDeviceStatus? StatusLanDevice { get; internal set; }
        public double? MemoryUsage { get; internal set; }
        public double? ProcessorTime { get; internal set; }
        public MetricType TypeMonitor { get; internal set; }
        public bool IsResourceRequestSuccess { get; internal set; }

        //// УБРАТЬ !!!!!!!!!!!!!
        //public bool Equals(EndPointDataDTO other)
        //{
        //    if (other == null)
        //    {
        //        return false;
        //    }

        //    if (HttpErrorsCount == other.HttpErrorsCount && StatusLanDevice == other.StatusLanDevice)
        //    {
        //        return true;
        //    }

        //    return false;
        //}
    }
}
