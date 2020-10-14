using ECMonitoring.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECMonitoring.Models
{
    public class EndPointModel
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public string NetworkName { get; set; }
        public string Name { get; set; }
        public Data.TypeEndPoint TypeMonitor { get; set; }
        public int? HttpErrorsCount { get; set; }
        public LanDeviceStatus? StatusLanDevice { get; set; }
        public double? MemoryUsage { get; set; }
        public double? ProcessorTime { get; set; }
        public bool? IsResourceRequestSuccess { get; internal set; }

        public string GetMemoryUsageValue()
        {
            return
                MemoryUsage.HasValue && IsResourceRequestSuccess.HasValue && 
                IsResourceRequestSuccess.Value ? $"{MemoryUsage:N1}%" : string.Empty;
        }

        public string GetProcessorTimeValue()
        {
            return
                ProcessorTime.HasValue && IsResourceRequestSuccess.HasValue &&
                IsResourceRequestSuccess.Value ? $"{ProcessorTime:N1}%" : string.Empty;
        }
    }
}