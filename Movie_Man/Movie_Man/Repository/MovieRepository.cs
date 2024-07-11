using Movie_Man.Entities;

namespace Movie_Man.Repository
{
    public class MovieRepository : IMovieRepository
    {
        public bool Delete(int id)
        {
            using (var context = new MovieContext())
            {
              var mov=context.movie.Find(id);
                if (mov == null)
                {
                    return false;
                }
                context.movie.Remove(mov);
                context.SaveChanges();
                return true;

                
            }
            
        }
        public List<Movie> GetAll()
        {
            using (var context = new MovieContext())
            {
                var movies = from mov in context.movie select mov;
                return movies.ToList<Movie>();
            }
        }

        public List<Movie> GetById(int id)
        {
            using (var context = new MovieContext())
            {
                var movies = from mov in context.movie where mov.id == id select mov;
                return movies.ToList<Movie>();
            }
        }

        public bool Insert(Movie movie)
        {
            using (var context = new MovieContext())
            {
                context.Add(movie);
                context.SaveChanges(true);
                return true;
            }
        }

        public List<Movie> Search(string searchTearm)
        {
            using (var context = new MovieContext())
            {
                return context.movie.Where(m => m.title.Contains(searchTearm)).ToList();
            }
        }
        public List<Movie> Sort(string sortBy, bool ascending)
        {
           using (var context= new MovieContext())
            {
                var movies=from mov in context.movie select mov;
                switch (sortBy.ToLower())
                {
                    case "title":
                        movies=ascending?movies.OrderBy(m=>m.title) : movies.OrderByDescending(m=>m.title);
              
                        break;
                    case "releaseDate":
                        movies = ascending ? movies.OrderBy(m => m.releaseDate) : movies.OrderByDescending(m => m.releaseDate);
                        break;
                    case "description":
                        movies = ascending ? movies.OrderBy(m => m.description) : movies.OrderByDescending(m => m.description);
                     break;
                    case "actorName":
                        movies = ascending ? movies.OrderBy(m => m.actorName) : movies.OrderByDescending(m => m.actorName);
                        break;
                    default:
                        movies = ascending ? movies.OrderBy(m => m.id) : movies.OrderByDescending(m => m.id);
                        break;

                }
                return movies.ToList<Movie>();
            }
        }

        public List<Movie> SearchByReleaseDate(DateTime releaseDate)
        {
            using (var context = new MovieContext())
            {
                return context.movie.Where(m => m.releaseDate == releaseDate).ToList<Movie>();

            }

        }

        public bool Update(int id, Movie movie)
        {
            using (var context = new MovieContext())
            {
                context.movie.UpdateRange(movie);
                context.SaveChanges();
                return true;

            }
        }

       public List<Movie> SortByDate()
        {
            using (var context = new MovieContext())
            {
                // Sort movies by their ReleaseDate property in ascending order
                return context.movie.OrderBy(s => s.releaseDate).ToList();
            }
        }

    }
}