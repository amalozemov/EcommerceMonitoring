using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstrapMVCTest.Controllers
{
    // wireframe.cc
    // fortawesome.github.io/Font-Awesome/icons/
    // https://fontawesome.com/icons?from=io
    // https://ru.depositphotos.com/vector-images/%D1%81%D0%B8%D0%B3%D0%BD%D0%B0%D0%BB%D1%8C%D0%BD%D0%B0%D1%8F-%D0%BB%D0%B0%D0%BC%D0%BF%D0%B0.html
    // http://fonts4web.ru/
    // https://themes.getbootstrap.com/preview/?theme_id=19799

    public class BootstrapTestController : Controller
    {
        // GET: BootstrapTest
        public ActionResult Index()
        {
            return View();
        }
    }
}