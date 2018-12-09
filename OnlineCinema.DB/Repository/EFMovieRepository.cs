using System.Collections.Generic;
using System.Linq;
using OnlineCinema.DB.DataModels;
using OnlineCinema.DB.DTOs;

namespace OnlineCinema.DB.Repository
{
    public class EFMovieRepository : IMovieRepository
    {
        private OnlineCinemaDataModel _context;

        public EFMovieRepository(OnlineCinemaDataModel context)
        {
            _context = context;
        }

        public int Add(Movie movie)
        {
            _context.Movie.Add(movie);

            return movie.Id;
        }

        public void Delete(int id)
        {
            var movie = GetDeteils(id);

            movie.IsDeleted = true;
        }

        public List<Movie> Get()
        {
            return _context.Movie
                .Where(x => !x.IsDeleted.HasValue || !x.IsDeleted.Value)
                .ToList();
        }

        public Movie GetDeteils(int id)
        {
            return _context.Movie
                .Where(x => !x.IsDeleted.HasValue || !x.IsDeleted.Value)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(Movie movie)
        {
            var OldMovie = GetDeteils(movie.Id);

            OldMovie.Image = movie.Image;
            OldMovie.IsDeleted = movie.IsDeleted;
            OldMovie.Name = movie.Name;
            OldMovie.VideoLink = movie.VideoLink;
            OldMovie.GenreId = movie.GenreId;
        }
    }
}
