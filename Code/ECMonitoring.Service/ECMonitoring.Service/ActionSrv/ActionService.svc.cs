using GMCS.MTT.XRM.Application.Services.Common;
using GMCS.MTT.XRM.Domain.DTO.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ECMonitoring.Service.ActionSrv
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ActionService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы ActionService.svc или ActionService.svc.cs в обозревателе решений и начните отладку.
    //public class ActionService : WcfServiceBase, IActionService
    public class ActionService : IActionService
    {
        public ActionServiceRequestResult DoWork()
        {
            return new ActionServiceRequestResult() { ActionCode = "1", ActionMessage = "1234" };
            //return "{ CodeResult = \"1\", ErrorMessage = \"1234\" }";

            //var response = new ServiceResult<ActionServiceRequestResult>();
            ////response.Result.ActionCode = "1";
            ////response.Result.ActionMessage = "12345";
            //response.Result = new ActionServiceRequestResult () { ActionCode = "1", ActionMessage = "1234" };
            //response.RequestResult.CodeResult = "2";
            //response.RequestResult.ErrorMessage = "67890";
            //return response;
        }
    }
}
