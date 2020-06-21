using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMService.Storage
{
    internal class ResourceUsage
    {
        public int MemoryUsage { get; private set; }
        public int ProcessorTime { get; private set; }

        public ResourceUsage(int memoryUsage, int processorTime)
        {
            MemoryUsage = memoryUsage;
            ProcessorTime = processorTime;
        }
    }
}
