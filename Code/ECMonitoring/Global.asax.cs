using ECMService.Manager;
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

            var esMonitor = new ECMonitor();
            Application["EcMonitor"] = esMonitor;
        }

        protected void Application_End()
        {
            var ecMonitor = Application["EcMonitor"] as ECMonitor;
            if (ecMonitor != null)
            {
                ecMonitor.Dispose();
            }
        }
    }
}
