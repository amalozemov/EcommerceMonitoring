using AutoMapper;
using DBaseService.DTO;
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
        public ActionResult Index(int? serviceId)
        {
            //FormsAuthentication.SignOut();
            //Response.Redirect("~/ECM/Login");

            // 115, 117, 154

            var services = Repository.GetServices().ToList();
            serviceId = serviceId ?? services.OrderBy(s => s.Id).FirstOrDefault().Id;
            Logger.Info($"Количество сервисов = {services.Count}; Запрошенный сервис: {serviceId}");

            var endPoints = Repository.GetEndPoints(serviceId.Value).ToList();

            var model = new MainModel();
            //model.Services = services.Select(s => Mapper.Map<ClientServiceDTO, ServiceModel>(s)).ToList();
            model.Services = Mapper.Map<List<ClientServiceDTO>, List<ServiceModel>>(services);
            model.EndPoints = Mapper.Map<List<ClientEndPointDTO>, List<EndPointModel>>(endPoints);


            var srviceData = EcMonitor.GetServiceData(serviceId.Value);

            foreach (var data in srviceData.EndPointsData)
            {
                // тут 01.07.2020 MetricModel должна содержать такие же свойства как и EndPointDataDTO, значения этих всойств должны тут мэпиться.
                // при выполнении Ajax запроса тип и Id метрики можно получить в БД, или вернуть в EndPointDataDTO (предпочтительно)
                // на клиенте на странице сервиса 2 типа процедур: 1. для TCP/HTTP и 2. для ресурсов. В параметры этих процедур передаётся Id конечной точки и метрики)

                // на 01.07.2020 для начала выводить нижеполученные значения в интерфейс конечной точки (метрики)
                Logger.Info($"Для конечной точки с Id = {data.EndPointId} TCP Status = {data.StatusLanDevice};  Http Errors Count = {data.HttpErrorsCount}; MemoryUsage = {data.MemoryUsage}; ProcessorTime = {data.ProcessorTime}");
            }

            return View(model);
        }
    }
}