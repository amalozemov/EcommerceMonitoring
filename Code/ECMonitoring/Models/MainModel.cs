using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECMonitoring.Models
{
    public class MainModel
    {
        public IList<ServiceModel> Services { get; set; }
        public List<EndPointModel> EndPoints { get; set; }
    }
}