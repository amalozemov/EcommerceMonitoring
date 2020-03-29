using GMCS.MTT.XRM.Domain.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GMCS.MTT.XRM.Domain.DTO.Action
{
    [DataContract]
    public class ServiceResult<T>
    {
        [DataMember]
        public T Result { get; set; }

        [DataMember]
        public ServiceRequestResult RequestResult { get; set; } = new ServiceRequestResult();

        public ServiceResult()
        {
            RequestResult.CodeResult = "200";
            RequestResult.ErrorMessage = "OK";
        }

        
    }
}