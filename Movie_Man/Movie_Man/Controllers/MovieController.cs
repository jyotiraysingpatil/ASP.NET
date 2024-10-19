using Microsoft.AspNetCore.Mvc;
using Movie_Man.Entities;
using Movie_Man.Services;
namespace Movie_Man.Controllers
{    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private IMovieService movieService;
        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(movieService.GetAll());                           
        }

        [HttpGet("getById/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(movieService.GetById(id));
        }

        [HttpPost("insert/")]
        public IActionResult Insert(Movie movie)
        {
            return Ok(movieService.Insert(movie));
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, Movie movie)
        {
            return Ok(movieService.Update(id, movie));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = movieService.Delete(id);
            if (result)
            {
                return Ok(" deleted successfully.");
            }
            return NotFound(" not found.");
        }

        [HttpGet("sort")]
        public IActionResult Sort(string sortBy, bool ascending)
        {
            return Ok(movieService.Sort(sortBy, ascending));    
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return BadRequest("search tearm cannot be empty");

            }
            var mov=movieService.Search(search);
            return Ok(mov);
        }
        [HttpGet("sErtByR/{releaseDate}")]
      public IActionResult  SearchByReleaseDate(DateTime releaseDate){
            return Ok(movieService.SearchByReleaseDate(releaseDate));
        }

        [HttpGet("sortByD/")]
        public IActionResult SortByDate()
        {
            var sortedMovies = movieService.SortByDate();
            return Ok(sortedMovies);
        }



    }
}
