using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GMCS.MTT.XRM.Domain.DTO.Action
{
    [DataContract]
    public class ActionServiceRequestResult
    {
        [DataMember]
        public string ActionCode { get; set; }
        [DataMember]
        public string ActionMessage { get; set; }
    }
}
