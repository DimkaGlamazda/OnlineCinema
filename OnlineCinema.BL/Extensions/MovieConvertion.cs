using OnlineCinema.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.BL.Extensions
{
    static class MovieConvertion
    {
        public static MovieView ToViewModel (MovieDto movieDto)
        {
            if (movieDto == null)
            {
                return null;
            }

            return new MovieView
            {
                Id = movieDto.Id,
                GenreId = movieDto.GenreId,
                Name = movieDto.Name,
                Image = movieDto.Image,
                VideoLink = movieDto.VideoLink,
                IsDeleted = movieDto.IsDeleted,
                Genre = movieDto.Genre.ToViewModel()
            };
        }

        public static MovieDto ToDtoModel(MovieView movieView)
        {
            if (movieView == null)
            {
                return null;
            }

            return new MovieDto
            {
                Id = movieView.Id,
                GenreId = movieView.GenreId,
                Name = movieView.Name,
                Image = movieView.Image,
                VideoLink = movieView.VideoLink,
                IsDeleted = movieView.IsDeleted,
                Genre = movieView.Genre.ToDtoModel()
            };
        }
    }

    //complete del class in future
    public class MovieDto
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string VideoLink { get; set; }
        public bool IsDeleted { get; set; }
        public virtual GenreView Genre { get; set; }
    }
}
