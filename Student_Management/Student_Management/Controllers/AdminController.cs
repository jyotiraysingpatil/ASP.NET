// AdminController.cs (Controllers/AdminController.cs)
using Microsoft.AspNetCore.Mvc;
using Student_Management.Entities;

namespace Student_Management.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private bool IsValidAdmin(string username, string password)
        {
            // Replace this with your actual admin validation logic
            return username == "jyoti" && password == "hi";
        }

        [HttpPost("authenticate")]
        public IActionResult AdminLogin([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!IsValidAdmin(loginRequest.username, loginRequest.password))
            {
                return Unauthorized("Invalid credentials.");
            }

            var adminUser = new { Username = loginRequest.username, Role = "admin" };
            return Ok(adminUser);
        }
    }
}
