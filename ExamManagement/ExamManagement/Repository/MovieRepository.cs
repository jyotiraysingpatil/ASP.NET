using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ExamManagement.Entities;

namespace ExamManagement.Repository
{
    public class MovieRepository : IMovieRepository
    {
        public bool DeleteMovieDetails(int id)
        {
            using (var context = new MovieContext())
            {
                var remove=from stud in context.Movies where stud.Id == id select stud;
                context.SaveChanges();
            }
            return true;
        }

        public List<Movie> GetAll()
        {
            using (var context = new MovieContext())
            {
                var movies = from mov in context.Movies select mov;
                return movies.ToList<Movie>();

            }
        }

        public List<Movie> GetMovieById(int id)
        {
            using (var context = new MovieContext())
            {
                var movies = from mov in context.Movies where mov.Id == id select mov;
                return movies.ToList<Movie>();
            }
        }

        public bool InsertMovieDetails(Movie movie)
        {
            using (var context = new MovieContext())
            {
                context.Movies.Add(movie);
                context.SaveChanges();
                return true;
            }
        }

        public bool UpdateMovieDetails(int id,Movie movie)
        {
            using (var context = new MovieContext())
            {
                context.Movies.UpdateRange(movie);
                context.SaveChanges(true);
                return true;
            }
        }
    }
}