using ECMonitoring.Models.EcMonitoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECMonitoring.Controllers
{
    public class EcMonitoringController : Controller
    {
        DBContext _dbContext;

        public EcMonitoringController()
        {
            // создаем контекст данных
            _dbContext = new DBContext();
        }

        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            var metrics = _dbContext.Metrics.ToList();

            var t = metrics.Count;

            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Books = metrics;

            return View();
        }

        
    }
}