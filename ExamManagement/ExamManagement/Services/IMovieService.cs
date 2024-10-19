using ExamManagement.Entities;
using ExamManagement.Repository;
namespace ExamManagement.Services
{
    namespace ExamManagement.Services
    {
        public interface IMovieService
        {
            List<Movie> GetAll();
            List<Movie> GetMovieById(int id);

            Boolean InsertMovieDetails(Movie movie);
            Boolean UpdateMovieDetails(int id,Movie movie);
            Boolean DeleteMovieDetails(int id);
        }
    }
}
