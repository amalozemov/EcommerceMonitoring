using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECMonitoring.Models
{
    public class MetricModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MetricType { get; set; }
    }
}