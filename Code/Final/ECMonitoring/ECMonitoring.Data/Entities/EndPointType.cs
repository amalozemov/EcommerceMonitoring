using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Data
{
    public class EndPointType : Entity
    {
        public EndPointType()
        {
            this.EndPoints = new HashSet<EndPoint>();
        }

        public string Description { get; set; }
        public TypeEndPoint? Value { get; set; }

        public virtual ICollection<EndPoint> EndPoints { get; set; }
    }
}
