using Microsoft.AspNetCore.Mvc;
using StudentManagement.Entities;
using StudentManagement.Services;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_studentService.GetAll());
        }

        [HttpGet("getById/{id}")]
        public IActionResult GetById(int id)
        {
            var student = _studentService.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateStatus(int id, [FromBody] string status)
        {
            if (string.IsNullOrEmpty(status))
            {
                return BadRequest("Status cannot be null or empty.");
            }

            var result = _studentService.UpdateStatus(id, status);
            if (result)
            {
                return Ok("Status updated successfully.");
            }
            return NotFound("Student not found.");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteStatus(int id)
        {
            var result = _studentService.DeleteStatus(id);
            if (result)
            {
                return Ok("Student deleted successfully.");
            }
            return NotFound("Student not found.");
        }

        
        }
    }

