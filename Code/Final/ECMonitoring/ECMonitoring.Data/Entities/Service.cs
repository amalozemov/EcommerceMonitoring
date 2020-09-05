using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Data
{
    public class Service : Entity
    {
        public Service()
        {
            this.EndPoints = new HashSet<EndPoint>();
        }

        public string Name { get; set; }

        public virtual ICollection<EndPoint> EndPoints { get; set; }
    }
}
