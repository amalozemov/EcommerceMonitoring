using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECMonitoring.Models
{
    public class MainModel
    {
        public int ServiceId { get; set; }
        public IList<ServiceModel> Services { get; set; }
        public List<EndPointModel> EndPoints { get; set; }
        public string UserName { get; set; }
    }
}