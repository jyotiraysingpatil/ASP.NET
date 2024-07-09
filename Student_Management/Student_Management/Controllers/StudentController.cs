using Microsoft.AspNetCore.Mvc;
using Student_Management.Entities;
using Student_Management.Services;

namespace Student_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private IStudentServicecs studentServicecs;
        public StudentController(IStudentServicecs studentServicecs)
        {
            this.studentServicecs = studentServicecs;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(studentServicecs.GetAll());

        }

        [HttpGet("getById/{id}")]
        public IActionResult GetStudentById(int id)
        {
            return Ok(studentServicecs.GetStudentById(id));
        }

        [HttpPost("insert/")]
        public IActionResult InsertStudentDetails(Student student)
        {
            return Ok(studentServicecs.InsertStudentDetails(student));
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateStudentDetails(int id, Student student)
        {
            return Ok(studentServicecs.UpdateStudentDetails(id, student));
        }
        [HttpDelete("delete/{id}")]
        public IActionResult  DeleteStudentDetails(int id)
        {
            return Ok(studentServicecs.DeleteStudentDetails(id));
        }

        [HttpGet("search")]
        public IActionResult searchStudent(string searchTerm)
        {
            var results = studentServicecs.searchStudnt(searchTerm);
            return Ok(results);
        }


        [HttpGet("sort")]
        public IActionResult SortStudents(string sortBy, bool ascending = true)
        {
            return Ok(studentServicecs.SortStudents(sortBy, ascending));
        }

    }
}
