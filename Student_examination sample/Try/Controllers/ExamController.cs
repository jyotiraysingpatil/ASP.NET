using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Try.Entities;
using Try.Services;

namespace Try.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService examService;
        public ExamController(IExamService examService)
        {
            this.examService = examService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var exams = await examService.GetAll();
                return Ok(new { Success = true, Data = exams });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "error " });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Exam exam)
        {
            if (exam == null)
            {
                return BadRequest(new { Success = false, Message = "invalid details" });
            }
            try
            {
                bool result = await examService.Insert(exam);
                if (result)
                {
                    return CreatedAtAction(nameof(GetAll), new
                    {
                        exam_id = exam.exam_id
                    }, new
                    {
                        Success = true,
                        Message = "exam created successfully"
                    });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "not inserted" });
                }
            }
            catch (Exception ex)
            {
                {
                    return StatusCode(500, new { Success = false, Message = "An error occurred while creating the student." });
                }
            }
        }

        [HttpPut("{exam_id}")]
        public async Task<IActionResult> Update(int exam_id, [FromBody] Exam exam)
        {
            if (exam == null || exam_id != exam.exam_id)
            {
                return BadRequest(new { Success = false, Message = "Invalid details" });
            }
            try
            {
                bool result = await examService.Update(exam);
                if (result)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound(new { Success = false, Message = "Exam not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpDelete("{exam_id}")]
        public async Task<IActionResult> Delete(int exam_id)
        {
            try
            {
                bool result = await examService.Delete(exam_id);
                if (result)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound(new { Success = false, Message = "Exam not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }
    }
}
