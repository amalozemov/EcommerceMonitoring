using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Data
{
    public class EndPoint : Entity
    {
        public long? ServiceId { get; set; }
        public long? EndPointTypeId { get; set; }
        public long? RequestContentsTypeId { get; set; }
        public string Ip { get; set; }
        public int? Port { get; set; }
        public string Name { get; set; }
        public string NetworkName { get; set; }

        public virtual EndPointType EndPointType { get; set; }
        public virtual Service Service { get; set; }
        public virtual RequestContentsType RequestContentsType { get; set; }

        public TypeEndPoint TypeMonitor
        {
            get
            {
                return (TypeEndPoint)EndPointType.Value;
            }
        }

        public TypeRequestContents RequestType
        {
            get
            {
                return (TypeRequestContents)RequestContentsType.Value;
            }
        }

    }
}
