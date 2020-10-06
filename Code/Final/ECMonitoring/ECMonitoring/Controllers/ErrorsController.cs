using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECMonitoring.Controllers
{
    public class ErrorsController : Controller
    {
        public ActionResult General(string errorMessage)
        {
            return View("~/Views/Errors/General.cshtml", null, errorMessage);
        }
    }
}