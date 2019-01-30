using StudentDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentDatabase.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolContext _context = new SchoolContext();

        public ActionResult Index()
        {
            var context = new SchoolContext();
            var student = context.Students.First();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}