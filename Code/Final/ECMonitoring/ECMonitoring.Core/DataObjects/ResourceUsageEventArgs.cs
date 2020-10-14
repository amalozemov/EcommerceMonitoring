using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Core
{

    public class ResourceUsageEventArgs
    {
        public double TotalVisibleMemorySize { get; internal set; }
        public double FreePhysicalMemory { get; internal set; }
        public double FreeVirtualMemory { get; internal set; }
        public double TotalVirtualMemorySize { get; internal set; }
        public double BusyPhysicalMemory
        {
            get
            {
                return TotalVisibleMemorySize - FreePhysicalMemory;
            }
        }
        public double BusyPhysicalMemoryPercent
        {
            get
            {
                return (BusyPhysicalMemory / TotalVisibleMemorySize) * 100;
            }
        }
        public double PercentIdleTime { get; internal set; }
        public double PercentProcessorTime { get; internal set; }
        public bool IsSuccess { get; internal set; } = true;

        public ResourceUsageEventArgs()
        {
        }
    }
}
