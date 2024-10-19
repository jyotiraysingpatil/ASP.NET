using ExamManagement.Entities;
using ExamManagement.Repository;
using ExamManagement.Services.ExamManagement.Services;

namespace ExamManagement.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public bool DeleteMovieDetails(int id)
        {
           return _movieRepository.DeleteMovieDetails(id);
        }

        public List<Movie> GetAll()
        {
            return _movieRepository.GetAll();
        }

        public List<Movie> GetMovieById(int id)
        {
            return _movieRepository.GetMovieById(id);
        }

        public bool InsertMovieDetails(Movie movie)
        {
           return _movieRepository.InsertMovieDetails(movie);
        }

        public bool UpdateMovieDetails(int id,Movie movie)
        {
            return _movieRepository.UpdateMovieDetails(id,movie);
        }


    }
}
