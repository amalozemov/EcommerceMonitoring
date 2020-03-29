using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GMCS.MTT.XRM.Domain.DTO.Common
{
    [DataContract]
    public class ServiceRequestResult
    {
        [DataMember]
        public string CodeResult { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
    }
}
