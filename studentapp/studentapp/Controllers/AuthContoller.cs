using Microsoft.AspNetCore.Mvc;
using studentapp.Models;
using studentapp.Services;

namespace studentapp.Controllers
{
    public class AuthController : Controller
    {
        private IStudentService _studentService;

        public AuthController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (email == "ravi.tambade@transflower.in"
                && password == "seed")
            {
                return RedirectToAction("index", "products");
            }
            return View();
        }

     
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(int id,string name,string course,string email,string password)
        {

            StudentViewModel user = new StudentViewModel();
            user.Id = id;
            user.Name = name;
            user.course = course;
            user.email = email;
            user.password = password;
            _studentService.Insert(user);
            return View();
        }
    }

}
