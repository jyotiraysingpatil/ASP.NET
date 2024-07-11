using Movie_Man.Entities;
using Movie_Man.Repository;

namespace Movie_Man.Services
{
    public class MovieService : IMovieService
    {
        private IMovieRepository repository;
        public MovieService(IMovieRepository repository)
        {
            this.repository = repository;
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        public List<Movie> GetAll()
        {
            return repository.GetAll();
        }

        public List<Movie> GetById(int id)
        { return repository.GetById(id);
        }

        public bool Insert(Movie movie)
        {
            return repository.Insert(movie);
        }

        public List<Movie> Search(string searchTearm)
        {
            return repository.Search(searchTearm);
        }

        public List<Movie> SearchByReleaseDate(DateTime releaseDate)
        {
            return repository.SearchByReleaseDate(releaseDate);
        }

        public List<Movie> Sort(string sortBy, bool ascending)
        {
            return repository.Sort(sortBy, ascending);
        }

        public List<Movie> SortByDate()
        {
           return repository.SortByDate();
        }

        public bool Update(int id, Movie movie)
        {
            return repository.Update(id, movie);
        }

        
    }
}
