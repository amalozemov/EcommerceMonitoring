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
        [AllowAnonymous] // убрать для появления окна Входа
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
            model.Services = Mapper.Map<List<ClientServiceDTO>, List<ServiceModel>>(services);
            model.EndPoints = Mapper.Map<List<ClientEndPointDTO>, List<EndPointModel>>(endPoints);
            model.ServiceId = serviceId.Value;
            model.ServiceName = services.Where(s => s.Id == serviceId).FirstOrDefault().Name;
            model.UserName = "Администратор"; //"Пушкин А.С.";//

            var serviceData = EcMonitor.GetServiceData(serviceId.Value);

            foreach (var endPoint in model.EndPoints)
            {
                var endPointData = 
                    serviceData.EndPointsData.Where(p => p.EndPointId == endPoint.Id).FirstOrDefault();
                if (endPoint.TypeMonitor == MonitorType.LanMonitor)
                {
                    endPoint.StatusLanDevice = endPointData.StatusLanDevice;
                    endPoint.HttpErrorsCount = endPointData.HttpErrorsCount;
                }
                else if (endPoint.TypeMonitor == MonitorType.ResourceMonitor)
                {
                    endPoint.ProcessorTime = endPointData.ProcessorTime;
                    endPoint.MemoryUsage = endPointData.MemoryUsage;
                }
                else
                {
                    throw new NotImplementedException("Данный тип конечной точки не поддерживается.");
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        public JsonResult GetServiceData(int serviceId)
        {
            var responseData = EcMonitor.GetServiceData(serviceId);
            var metricsData = new List<object>();
            
            foreach (var endPoint in responseData.EndPointsData)
            {
                object metricData = null;

                if (endPoint.TypeMonitor == MetricType.LanMonitor)
                {
                    metricData = new { metricType = 0, elementKey = $"{endPoint.EndPointId}", statusLanDevice = endPoint.StatusLanDevice.ToString(), httpErrorsCount = endPoint.HttpErrorsCount };
                }
                else if (endPoint.TypeMonitor == MetricType.ResourceMonitor)
                {
                    metricData = new { metricType = 1, elementKey = $"{endPoint.EndPointId}", memoryUsage = endPoint.MemoryUsage, processorTime = endPoint.ProcessorTime };
                }
                else
                {
                    throw new NotImplementedException("Данный тип конечной точки не поддерживается.");
                }

                metricsData.Add(metricData);
            }

            var result = Json(metricsData, JsonRequestBehavior.AllowGet);

            return result;
        }

        [AllowAnonymous]
        public JsonResult HttpErrorsReset(int endPointId)
        {
            EcMonitor.HttpErrorsReset(endPointId);

            var result = Json(new { sucess = true }, JsonRequestBehavior.AllowGet);

            return result;
        }
    }
}