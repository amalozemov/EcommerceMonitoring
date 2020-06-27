using System.Web.Mvc;
using DBaseService;
using ECMonitoring.Infrastructure;
using ECMService.Manager;
using NLog;

namespace ECMonitoring.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected Logger Logger { get; private set; }
        protected ECMonitor EcMonitor { get; private set; }
        protected IRepository Repository { get; private set; }
        protected IAuthProvider AuthProvider { get; private set; }

        protected ControllerBase()
        {
            Logger = LogManager.GetLogger("ECMonitoring");
            EcMonitor = (ECMonitor)System.Web.HttpContext.Current.Application["EcMonitor"];
            Repository = new FakeRepository();
            AuthProvider = new FormAuthProvider(Repository);
        }
    }
}