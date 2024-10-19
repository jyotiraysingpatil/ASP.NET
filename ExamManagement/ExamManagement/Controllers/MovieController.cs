using Microsoft.AspNetCore.Mvc;
using ExamManagement.Entities;
using ExamManagement.Services;
using System.Collections.Generic;
using ExamManagement.Services.ExamManagement.Services;


namespace ExamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/movie
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_movieService.GetAll());
        }

        [HttpGet("getById/{id}")]
       public IActionResult GetMovieById(int id)
        {
            return Ok(_movieService.GetMovieById(id));
        }

        [HttpPost("insert/")]
       public IActionResult InsertMovieDetails(Movie movie)
        {
            return Ok(_movieService.InsertMovieDetails(movie));
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateMovieDetails(int id,Movie movie)
        {
            return Ok(_movieService.UpdateMovieDetails(id,movie));
        }

        [HttpDelete("delete/{id}")]
       public IActionResult DeleteMovieDetails(int id)
        {
            return Ok(_movieService.DeleteMovieDetails(id));
        }
    }
}
