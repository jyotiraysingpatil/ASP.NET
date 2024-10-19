using Movie_Man.Entities;

namespace Movie_Man.Repository
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        List<Movie>GetById(int id);     
     Boolean Insert(Movie movie);
        Boolean Update(int id,Movie movie);
        Boolean Delete(int id);
        List<Movie> Sort(string sortBy, bool ascending);
        List<Movie> Search(string searchTearm);
        List<Movie> SearchByReleaseDate(DateTime releaseDate);

        List<Movie> SortByDate();

    }
}
