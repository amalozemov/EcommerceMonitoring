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
            //model.Services = services.Select(s => Mapper.Map<ClientServiceDTO, ServiceModel>(s)).ToList();
            model.Services = Mapper.Map<List<ClientServiceDTO>, List<ServiceModel>>(services);
            model.EndPoints = Mapper.Map<List<ClientEndPointDTO>, List<EndPointModel>>(endPoints);
            model.ServiceId = serviceId.Value;
            model.ServiceName = services.Where(s => s.Id == serviceId).FirstOrDefault().Name;
            model.UserName = "Администратор"; //"Пушкин А.С.";//

            var srviceData = EcMonitor.GetServiceData(serviceId.Value);

            foreach (var endPoint in srviceData.EndPointsData)
            {
                // тут 01.07.2020 MetricModel должна содержать такие же свойства как и EndPointDataDTO, значения этих всойств должны тут мэпиться.
                // при выполнении Ajax запроса тип и Id метрики можно получить в БД, или вернуть в EndPointDataDTO (предпочтительно)
                // на клиенте на странице сервиса 2 типа процедур: 1. для TCP/HTTP и 2. для ресурсов. В параметры этих процедур передаётся Id конечной точки и Id метрики)

                // на 01.07.2020 для начала выводить нижеполученные значения в интерфейс конечной точки (метрики)
                Logger.Info($"Для конечной точки с Id = {endPoint.EndPointId} TCP Status = {endPoint.StatusLanDevice};  Http Errors Count = {endPoint.HttpErrorsCount}; MemoryUsage = {endPoint.MemoryUsage}; ProcessorTime = {endPoint.ProcessorTime}");

                var metrics = 
                    Mapper.Map<List<ClientMetricDTO>, List<MetricModel>>(Repository.GetMetrics(endPoint.EndPointId));

                var ep = model.EndPoints.Where(e => e.Id == endPoint.EndPointId).FirstOrDefault();
                ep.Metrics = metrics;
                foreach (var metric in ep.Metrics)
                {
                    if (metric.MetricType == (int)MonitorType.LanMonitor)
                    {
                        metric.StatusLanDevice = endPoint.StatusLanDevice;
                        metric.HttpErrorsCount = endPoint.HttpErrorsCount;
                    }
                    else if (metric.MetricType == (int)MonitorType.ResourceMonitor)
                    {
                        metric.MemoryUsage = endPoint.MemoryUsage;
                        metric.ProcessorTime = endPoint.ProcessorTime;
                    }
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        public JsonResult GetServiceData(int serviceId)
        {
            var t = serviceId;

            var responseData = EcMonitor.GetServiceData(serviceId);

            //var serviceData = new List<object>();

            //var endPointData = new List<object>();
            var metricsData = new List<object>();
            foreach (var endPoint in responseData.EndPointsData)
            {
                //var endPointData = new Dictionary<int, object>();
                //var endPointData = new List<object>();
                //{
                //    {endPoint.EndPointId, new { } }
                //};

                var metrics =
                    Mapper.Map<List<ClientMetricDTO>, List<MetricModel>>(Repository.GetMetrics(endPoint.EndPointId));

                //var metricsData = new List<object>(); 
                foreach (var metric in metrics)
                {
                    object metricData = null;
                    //var elementKey = default(string); $"{endPoint.EndPointId}_{metric.Id}";
                    if (metric.MetricType == (int)MonitorType.LanMonitor)
                    {
                        //metric.StatusLanDevice = endPoint.StatusLanDevice;
                        //metric.HttpErrorsCount = endPoint.HttpErrorsCount;
                        //metricData = new { metricType = 0, endPointId = endPoint.EndPointId, metricId = metric.Id, statusLanDevice = endPoint.StatusLanDevice, httpErrorsCount = endPoint.HttpErrorsCount };

                        //var elementKey = $"{endPoint.EndPointId}_{metric.Id}";
                        //var elementKey = $"{metric.Id}";
                        metricData = new { metricType = 0, elementKey = $"{metric.Id}", statusLanDevice = endPoint.StatusLanDevice.ToString(), httpErrorsCount = endPoint.HttpErrorsCount };
                    }
                    else if (metric.MetricType == (int)MonitorType.ResourceMonitor)
                    {
                        //metric.MemoryUsage = endPoint.MemoryUsage;
                        //metric.ProcessorTime = endPoint.ProcessorTime;
                        metricData = new { metricType = 1, elementKey = $"{metric.Id}", memoryUsage = endPoint.MemoryUsage, processorTime = endPoint.ProcessorTime };
                    }

                    metricsData.Add(metricData);

                }

                //endPointData.Add(endPoint.EndPointId, metricsData);
                //endPointData.Add(metricsData);
                //serviceData.Add(endPointData);
            }


            //var result = Json(serviceData, JsonRequestBehavior.AllowGet);
            //var result = Json(new { test = 1}, JsonRequestBehavior.AllowGet);
            var result = Json(metricsData, JsonRequestBehavior.AllowGet);

            return result;
        }
    }
}