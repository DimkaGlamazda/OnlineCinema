using OnlineCinema.BL.Model;
using OnlineCinema.BL.Services;
using OnlineCinema.DB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.BL.Extensions
{
    public static class MovieConvertion
    {
        public static MovieAdminView ToAdminViewModel(this MovieDto movieDto)
        {
            if (movieDto == null)
            {
                return null;
            }

            return new MovieAdminView
            {
                Id = movieDto.Id,
                GenreId = movieDto.GenreId,
                Name = movieDto.Name,
                Image = movieDto.Image,
                VideoLink = movieDto.VideoLink,
                Genre = movieDto.Genre.ToViewModel()
            };
        }

        public static MovieView ToViewModel (this MovieDto movieDto)
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
                Genre = movieDto.Genre.ToViewModel()
            };
        }

        public static MovieDto ToDtoModel(this IMovieViewModel movieView)
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
                Genre = movieView.Genre.ToDtoModel()
            };
        }
    }
}
