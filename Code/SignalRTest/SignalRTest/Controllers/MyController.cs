using SignalRTest.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// https://metanit.com/sharp/mvc5/16.5.php

namespace SignalRTest.Controllers
{
    public class MyController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SendMessageAllClients()
        {
            var test = HttpContext.Application["Test"];
            HttpContext.Application["Test"] = Convert.ToInt32(test) + 1;

            SendMessage(HttpContext.Application["Test"].ToString());

            var res = Json(new { Result = HttpContext.Application["Test"] }, JsonRequestBehavior.AllowGet);
           
            return res;
        }

        private void SendMessage(string message)
        {
            // Получаем контекст хаба
            var context =
                Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            // отправляем сообщение
            context.Clients.All.displayMessage(message);
        }
    }
}