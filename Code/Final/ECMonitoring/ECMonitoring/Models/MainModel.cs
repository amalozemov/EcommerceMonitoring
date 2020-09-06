using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECMonitoring.Models
{
    public class MainModel
    {
        public long ServiceId { get; set; }
        public string ServiceName { get; set; }
        public IList<ServiceModel> Services { get; set; }
        public List<EndPointModel> EndPoints { get; set; }
        public string UserName { get; set; }
    }
}