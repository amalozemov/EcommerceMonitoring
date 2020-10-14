using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Service.Storage
{
    internal class ResourceUsage
    {
        public double MemoryUsage { get; private set; }
        public double ProcessorTime { get; private set; }
        public bool IsSuccess { get; private set; } = false;

        public ResourceUsage()
        {
        }

        public ResourceUsage(double memoryUsage, double processorTime, bool isSuccess)
        {
            MemoryUsage = memoryUsage;
            ProcessorTime = processorTime;
            IsSuccess = isSuccess;
        }
    }
}
