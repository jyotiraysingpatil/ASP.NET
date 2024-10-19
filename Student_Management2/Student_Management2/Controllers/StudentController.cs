using Microsoft.AspNetCore.Mvc;
using Student_Management2.Models;
using Student_Management2.Services;
namespace Student_Management2.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            return View(students);
        }

    }
}
