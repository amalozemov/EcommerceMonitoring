using DBaseService.DTO;
using ECMService.Manager;
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
        //public List<MetricModel> Metrics { get; set; }
        public MonitorType TypeMonitor { get; set; }
        public int? HttpErrorsCount { get; set; }
        public LanDeviceStatus? StatusLanDevice { get; set; }
        public int? MemoryUsage { get; set; }
        public int? ProcessorTime { get; set; }
    }
}