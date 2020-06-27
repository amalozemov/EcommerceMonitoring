using ECMonitoring.Models;
using ECMService.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ECMonitoring.Controllers
{
    // аутентификация
    // https://metanit.com/sharp/mvc/11.3.php
    // https://professorweb.ru/my/ASP_NET/mvc/level5/5_1.php
    // https://professorweb.ru/my/ASP_NET/gamestore/level2/2_12.php

    [Authorize]
    public class ECMController : ControllerBase
    {

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model)//, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (AuthProvider.Authenticate(model.UserName, model.Password))
                {
                    //FormsAuthentication.SetAuthCookie(model.UserName, false);// true);
                    return RedirectToAction("Index", "ECM");
                    //return RedirectToAction(returnUrl ?? Url.Action("Index", "ECM"));
                }
                else
                {
                    ModelState.AddModelError("", "Неверное имя пользователя или пароль");
                }
            }
            return View(model);
        }

        // GET: ECM
        public ActionResult Index()
        {
            //FormsAuthentication.SignOut();
            //Response.Redirect("~/ECM/Login");

            var srviceId = 0;
            var srviceData = EcMonitor.GetServiceData(srviceId);

            foreach (var data in srviceData.EndPointsData)
            {
                Logger.Info($"Для конечной точки с Id = {data.EndPointId} TCP Status = {data.StatusLanDevice};  Http Errors Count = {data.HttpErrorsCount}; MemoryUsage = {data.MemoryUsage}; ProcessorTime = {data.ProcessorTime}");
            }

            return View();
        }
    }
}