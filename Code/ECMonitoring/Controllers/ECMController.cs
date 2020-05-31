using ECMService.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECMonitoring.Controllers
{
    public class ECMController : Controller
    {
        // GET: ECM
        public ActionResult Index()
        {
            // тут 31.05.2020 ECMService.Manager подключать к Десктоп клиенту ECMService.DesctopClient и программировать его:
            //     1) Таймер забирает сразу все данные (по всем сервисам и конечным точкам) 
            //     2) ECMService.Manager отдаёт данные по каждой конечной точке определяя изменились ли они по отношению к предыдущему запросу (для SignalR можно предусмотреть события) 

            EndPointDataDTO data;
            var esMonitor = HttpContext.Application["EsMonitor"] as ECMonitor;
            var t = esMonitor.GetDataByEndPointId(0, out data);

            return View();
        }
    }
}