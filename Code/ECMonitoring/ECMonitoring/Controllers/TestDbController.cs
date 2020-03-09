using ECMonitoring.Models.ECommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECMonitoring.Controllers
{
    public class TestDbController : Controller
    {
        DBContext _dbContext;

        public TestDbController()
        {
            // создаем контекст данных
            _dbContext = new DBContext();
        }

        public ActionResult Index()
        {
            //// получаем из бд все объекты Book
            //var books = _dbContext.Books.ToList();

            //var t = books.Count;

            //// передаем все объекты в динамическое свойство Books в ViewBag
            //ViewBag.Books = books;

            return View();
        }

    }
}