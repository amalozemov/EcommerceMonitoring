using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Core
{

    public class ResourceUsageEventArgs
    {
        public int MemoryUsage { get; private set; }
        public int ProcessorTime { get; private set; }

        public ResourceUsageEventArgs(int memoryUsage, int processorTime)
        {
            MemoryUsage = memoryUsage;
            ProcessorTime = processorTime;
        }
    }
}
