using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;
using Try.Entities;
using Try.Services;

namespace Try.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var students = await _service.GetAll();
                return Ok(new { Success = true, Data = students });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "An error occurred while fetching the data." });
            }
        }


        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest(new { Success = false, Message = "invalid details" });
            }
            try
            {
                bool result = await _service.Insert(student);
                if (result)
                {
                    return CreatedAtAction(nameof(GetAll), new
                    {
                        id = student.id
                    }, new
                    {
                        Success = true,
                        Message = "student created successfully"
                    });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Failed to create student." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "An error occurred while creating the student." });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, Student student)
        {
            if (student == null)
            {
                return BadRequest(new { Success = false, Message = "invalid " });
            }
            try
            {
                bool result = await _service.Update(student);
                if (result)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound(new { Success = false, Message = "not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "internal server error"
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                bool result = await _service.Delete(id);
                if (result)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound(new
                    {
                        Success = false,
                        Message = "not found"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "internal server error" });
            }
        }

    }
}