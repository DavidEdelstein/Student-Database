using StudentDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentDatabase.Controllers
{
    public class CourseController : Controller
    {
        private readonly SchoolContext _context = new SchoolContext();
        // GET: Course generate courses for courses.
        public ActionResult Index()
        {
            //var context = new SchoolContext();
            var Course = _context.Courses;
            return View(Course);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course newcourse)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(newcourse);
                _context.SaveChanges();
                return RedirectToAction("Index");
                //add new student to student table
            }
            else
            {
                ViewBag.ErrorMessage = "The info you have entered is not valid";
                return View();
            }
        }
    }
}