using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBaseService.DTO
{
    public enum MonitorType
    {
        LanMonitor = 0,
        ResourceMonitor = 1
    }

    public class ClientEndPointDTO
    {
        public int ServiceId { get; set; }
        public int Id { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public string NetworkName { get; set; }
        public string Name { get; set; }
        //public List<ClientMetricDTO> Metrics { get; set; }
        public MonitorType TypeMonitor { get; set; }
    }
}
