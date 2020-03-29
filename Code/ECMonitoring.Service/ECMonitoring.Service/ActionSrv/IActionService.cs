using GMCS.MTT.XRM.Domain.DTO.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ECMonitoring.Service.ActionSrv
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IActionService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IActionService
    {
        [WebInvoke(Method = "POST", /*UriTemplate = "CallAction",*/ RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        //ServiceResult<ActionServiceRequestResult> DoWork();
        ActionServiceRequestResult DoWork();
    }
}
