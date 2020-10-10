using ECMonitoring.Controllers;
using ECMonitoring.Logger;
using ECMonitoring.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ECMonitoring
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Configure();

            var esmManager = new ECMManager();
            Application["ECMManager"] = esmManager;
        }

        protected void Application_End()
        {
            var ecMonitor = Application["ECMManager"] as ECMManager;
            if (ecMonitor != null)
            {
                ecMonitor.Dispose();
            }
        }

        protected void Application_Error()
        {
            LoggingApplicationExceptions();
            var exception = Server.GetLastError();
            Response.Clear();
            Server.ClearError();
            var routeData = new RouteData();
            routeData.Values["controller"] = "Errors";
            routeData.Values["action"] = "General";
            routeData.Values["errorMessage"] = exception.Message;
            Response.StatusCode = 500;
            Response.TrySkipIisCustomErrors = true;
            IController errorsController = new ErrorsController();
            var wrapper = new HttpContextWrapper(Context);
            var rc = new RequestContext(wrapper, routeData);
            errorsController.Execute(rc);
        }

        /// <summary>
        /// Обработка ошибок уровня приложения
        /// </summary>
        private void LoggingApplicationExceptions()
        {
            var exception = Server.GetLastError();
            var logger = new EcmLogger("Web");
            logger.Error($"Произошла ошибка уровня приложения: {exception}");
        }
    }
}
