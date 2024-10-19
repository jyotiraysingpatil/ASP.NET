using ExamManagement.Entities;
namespace ExamManagement.Repository
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        List<Movie> GetMovieById(int id);
       Boolean InsertMovieDetails(Movie movie);
        Boolean UpdateMovieDetails(int id,Movie movie);
        Boolean DeleteMovieDetails(int id);


    }
}
