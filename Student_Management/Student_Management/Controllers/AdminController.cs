using Microsoft.AspNetCore.Mvc;
using Student_Management.Entities;
using Student_Management.Repository;
using System.Linq;

namespace Student_Management.Controllers
{
    public class AdminController : Controller
    {
        private StudentContext db = new StudentContext();
        private const string AdminUsername = "admin";
        private const string AdminPassword = "password";
        private static bool isAdminLoggedIn = false;
        [HttpPost]
        public IActionResult Index()
        {
            if (!isAdminLoggedIn)
            {
                return RedirectToAction("Login");
            }
            return View(db.student.ToList());
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == AdminUsername && password == AdminPassword)
            {
                isAdminLoggedIn = true;
                return RedirectToAction("Index");
            }

            ViewBag.ErrorMessage = "Invalid username or password";
            return View();
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            if (!isAdminLoggedIn)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if (!isAdminLoggedIn)
            {
                return RedirectToAction("Login");
            }

            if (ModelState.IsValid)
            {
                db.student.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }
    }
}
