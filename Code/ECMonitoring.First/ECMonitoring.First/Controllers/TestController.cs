using ECMonitoring.Core;
using ECMonitoring.First.Core;
using ECMonitoring.First.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECMonitoring.First.Controllers
{
    public class TestController : Controller
    {
        public TestController()
        {
            var t = 5;
        }
        //~TestController()
        //{
        //    var t = 5;
        //}
        //public new void Dispose()
        //{
        //    var t = 5;
        //}

        public ActionResult Index(string id)
        {
            var model = new ECMonitoringModel();

            if (string.IsNullOrWhiteSpace(id))
            {
                model.Service1Status = "Остановлен";
                model.Service2Status = "Остановлен";
                model.Service3Status = "Остановлен";
            }
            else
            {
                model.Service1Status = GetServiceStatus(id, "Service1");
                model.Service2Status = GetServiceStatus(id, "Service2");
                model.Service3Status = GetServiceStatus(id, "Service3");
            }

            HttpContext.Application["ServiceModel"] = model;
            return View(model);
        }

        private string GetServiceStatus(string id, string serviceName)
        {
            var prvModel = (ECMonitoringModel)HttpContext.Application["ServiceModel"];
            var ret = "Остановлен";

            #region Расширенный вариант
            //if (id == "Service1")
            //{
            //    if (id == serviceName)
            //    {
            //        if (prvModel.Service1Status == "Остановлен")
            //        {
            //            ret = "Выполняется";
            //        }
            //        else
            //        {
            //            ret = "Остановлен";
            //        }
            //    }
            //    else
            //    {
            //        if (serviceName == "Service2")
            //        {
            //            ret = prvModel.Service2Status;
            //        }
            //        else if (serviceName == "Service3")
            //        {
            //            ret = prvModel.Service3Status;
            //        }
            //    }
            //}
            //else if (id == "Service2")
            //{
            //    if (id == serviceName)
            //    {
            //        if (prvModel.Service2Status == "Остановлен")
            //        {
            //            ret = "Выполняется";
            //        }
            //        else
            //        {
            //            ret = "Остановлен";
            //        }
            //    }
            //    else
            //    {
            //        if (serviceName == "Service1")
            //        {
            //            ret = prvModel.Service1Status;
            //        }
            //        else if (serviceName == "Service3")
            //        {
            //            ret = prvModel.Service3Status;
            //        }
            //    }
            //}
            //else if (id == "Service3")
            //{
            //    if (id == serviceName)
            //    {
            //        if (prvModel.Service3Status == "Остановлен")
            //        {
            //            ret = "Выполняется";
            //        }
            //        else
            //        {
            //            ret = "Остановлен";
            //        }
            //    }
            //    else
            //    {
            //        if (serviceName == "Service1")
            //        {
            //            ret = prvModel.Service1Status;
            //        }
            //        else if (serviceName == "Service2")
            //        {
            //            ret = prvModel.Service2Status;
            //        }
            //    }
            //}
            #endregion

            if (id == "Service1")
            {
                if (id == serviceName)
                {
                    //if (prvModel.Service1Status == "Остановлен")
                    //{
                    //    ret = "Выполняется";
                    //}
                    //else
                    //{
                    //    ret = "Остановлен";
                    //}
                    ret = "Выполняется";
                }
            }
            else if (id == "Service2")
            {
                if (id == serviceName)
                {
                    //if (prvModel.Service2Status == "Остановлен")
                    //{
                    //    ret = "Выполняется";
                    //}
                    //else
                    //{
                    //    ret = "Остановлен";
                    //}
                    ret = "Выполняется";
                }
            }
            else if (id == "Service3")
            {
                if (id == serviceName)
                {
                    //if (prvModel.Service3Status == "Остановлен")
                    //{
                    //    ret = "Выполняется";
                    //}
                    //else
                    //{
                    //    ret = "Остановлен";
                    //}
                    ret = "Выполняется";
                }
            }


            return ret;
        }


        public ActionResult FakeArrivalStart()
        {
            //var monitor = new ECMonitoringPicap();

            //monitor.TcpArrivalHandler += Monitor_TcpArrivalHandler;

            //monitor.Start();

            var picapService = new WinPicapService();

            HttpContext.Application["PicapService"] = picapService;

            picapService.Start();

            return View();
        }

        public ActionResult FakeArrivalStop()
        {
            //var monitor = new ECMonitoringPicap();

            //monitor.TcpArrivalHandler += Monitor_TcpArrivalHandler;

            //monitor.Start();

            var picapService = (WinPicapService)HttpContext.Application["PicapService"];
            picapService.Stop();

            return View();
        }

        private void Monitor_TcpArrivalHandler(string message)
        {
            var t = message;
        }
    }
}