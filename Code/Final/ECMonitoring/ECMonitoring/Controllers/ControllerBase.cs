﻿using System.Configuration;
using System.Web.Configuration;
using System.Web.Mvc;
using ECMonitoring.Data;
using ECMonitoring.Data.EF;
using ECMonitoring.Data.Fake;
using ECMonitoring.Infrastructure;
using ECMonitoring.Manager;
using NLog;

namespace ECMonitoring.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected Logger Logger { get; private set; }
        protected ECMManager EcmManager { get; private set; }
        protected IUnitOfWorkFactory UnitOfWorkFactory { get; private set; }
        protected IAuthProvider AuthProvider { get; private set; }

        protected ControllerBase()
        {
            var connectionString =
                WebConfigurationManager.ConnectionStrings["ECMonitoring"].ConnectionString;
            UnitOfWorkFactory = new UnitOfWorkFactory(connectionString); ;// new FakeUnitOfWorkFactory(connectionString);
            Logger = LogManager.GetLogger("ECMonitoring");
            EcmManager = (ECMManager)System.Web.HttpContext.Current.Application["ECMManager"];
            AuthProvider = new FormAuthProvider(UnitOfWorkFactory);
        }

        /// <summary>
        /// Обработка ошибок уровня контроллера
        /// </summary>
        protected override void OnException(ExceptionContext filterContext)
        {
            Logger.Error("Произошла ошибка в приложении: {0}; Controller:{1}; Action:{3}; Url:{2}",
                filterContext.Exception, filterContext.RouteData.Values["controller"],
                filterContext.HttpContext.Request.Url, filterContext.RouteData.Values["action"]);
            filterContext.ExceptionHandled = true;
            filterContext.Result = View("~/Views/Errors/General.cshtml", null, filterContext.Exception.Message);
        }
    }
}