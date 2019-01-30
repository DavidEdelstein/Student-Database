using StudentDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentDatabase.Controllers
{
    public class StudentController : Controller
    {
        //this is going into the database to get the info
        private readonly SchoolContext _context = new SchoolContext();
        
        // GET: Student
        public ActionResult Index()
        {
            var students = _context.Students;
                          //.Where(s => s.ID >= 1 && s.ID <= 3)
                          //.FirstOrDefault();
            return View(students);
        }

        public ActionResult StudentID(int id)
        {
            var ID = _context.Students.Where(s => s.ID == id);
            return View("Index", ID);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student newstudent)
        {
            newstudent.EnrollmentDate = DateTime.Parse(newstudent.EnrollmentDate.ToString());
            if (ModelState.IsValid)
            {
                _context.Students.Add(newstudent);
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



        //public ActionResult StudentFirstName(string name)
        //{
        //    var FirstName = _context.Students.Where(s => s.FirstName == name);
        //    return View("Index",FirstName);
        //}
        //public ActionResult EnrollmentDate(DateTime date)
        //{
        //    var EnrollmentDate = _context.Students.Where(s => s.EnrollmentDate == date);
        //    return View("Index",EnrollmentDate);
        //}

    }
}