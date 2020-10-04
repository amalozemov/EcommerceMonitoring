using AutoMapper;
using ECMonitoring.Manager;
using ECMonitoring.Models;
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
        public ActionResult Login(bool? isSignOut)
        {
            //TempData["ErrorMessage"] = "Тестовая ошибка";
            //throw new Exception("Тестовая ошибка 1234");

            if (isSignOut.HasValue && isSignOut.Value)
            {
                AuthProvider.SignOut();
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model)
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
        //[AllowAnonymous] // убрать для появления окна Входа
        [OutputCache(NoStore = true, Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult Index(long? serviceId)
        {
            //FormsAuthentication.SignOut();
            //Response.Redirect("~/ECM/Login");

            // 115, 117, 154

            using (var uow = UnitOfWorkFactory.Create())
            {
                var repository = uow.GetRepository();
                var services = repository.GetEntities<Data.Service>().OrderBy(s => s.SequenceNumber).ToList();
                serviceId = serviceId ?? services[0].Id;
                //Logger.Info($"Количество сервисов = {services.Count}; Запрошенный сервис: {serviceId}");
                var endPoints = 
                    repository.GetEntities<Data.EndPoint>().Where(e => e.ServiceId == serviceId.Value).ToList();

                var model = new MainModel();
                model.Services = Mapper.Map<List<Data.Service>, List<ServiceModel>>(services);
                model.EndPoints = Mapper.Map<List<Data.EndPoint>, List<EndPointModel>>(endPoints);
                model.ServiceId = serviceId.Value;
                model.ServiceName = services.Where(s => s.Id == serviceId).FirstOrDefault().Name;
                model.UserName = HttpContext.User.Identity.Name; //"Пушкин А.С.";//

                var serviceData = EcmManager.GetServiceData(serviceId.Value);
                foreach (var endPoint in model.EndPoints)
                {
                    var endPointData =
                        serviceData.EndPointsData.Where(p => p.EndPointId == endPoint.Id).FirstOrDefault();
                    if (endPoint.TypeMonitor == Data.TypeEndPoint.LanMonitor)
                    {
                        endPoint.StatusLanDevice = endPointData?.StatusLanDevice;
                        endPoint.HttpErrorsCount = endPointData?.HttpErrorsCount;
                    }
                    else if (endPoint.TypeMonitor == Data.TypeEndPoint.ResourceMonitor)
                    {
                        endPoint.ProcessorTime = endPointData?.ProcessorTime;
                        endPoint.MemoryUsage = endPointData?.MemoryUsage;
                    }
                    else
                    {
                        throw new NotImplementedException("Данный тип конечной точки не поддерживается.");
                    }
                }

                return View(model);
            }
        }


        // где то тут 04.10.2020 -
        // 1) Обработка ошибок а Ajax методах
        // 2) Обработка серверных ошибок 

        [AllowAnonymous]
        public JsonResult GetServiceData(long serviceId)
        {
            var responseData = EcmManager.GetServiceData(serviceId);
            var serviceData = new List<object>();
            
            foreach (var endPoint in responseData.EndPointsData)
            {
                object monitorData = null;

                if (endPoint.TypeMonitor == MetricType.LanMonitor)
                {
                    monitorData = new { metricType = 0, elementKey = $"{endPoint.EndPointId}", statusLanDevice = endPoint.StatusLanDevice.ToString(), httpErrorsCount = endPoint.HttpErrorsCount };
                }
                else if (endPoint.TypeMonitor == MetricType.ResourceMonitor)
                {
                    monitorData = new { metricType = 1, elementKey = $"{endPoint.EndPointId}", memoryUsage = endPoint.MemoryUsage, processorTime = endPoint.ProcessorTime };
                }
                else
                {
                    throw new NotImplementedException("Данный тип конечной точки не поддерживается.");
                }

                serviceData.Add(monitorData);
            }

            var result = Json(serviceData, JsonRequestBehavior.AllowGet);

            return result;
        }

        [AllowAnonymous]
        public JsonResult HttpErrorsReset(long endPointId)
        {
            EcmManager.HttpErrorsReset(endPointId);
            var result = Json(new { sucess = true }, JsonRequestBehavior.AllowGet);
            return result;
        }
    }
}