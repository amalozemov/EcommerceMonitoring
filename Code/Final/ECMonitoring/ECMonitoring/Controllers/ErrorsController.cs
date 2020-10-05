using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECMonitoring.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult ErrorHandler()
        {
            //ViewBag["ErrorMessage"] = HttpContext.Error.Message;
            //var exception = Server.GetLastError();
            //var exception = HttpContext..
            //ViewBag["ErrorMessage"] = exception.Message;
            //return View(ViewBag);
            return View();
        }
    }
}