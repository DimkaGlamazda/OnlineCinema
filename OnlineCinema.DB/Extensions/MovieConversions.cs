using OnlineCinema.DB.DataModels;
using OnlineCinema.DB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.DB.Extensions
{
    public static class MovieConversions
    {
        public static Movie ToSqlModel(this MovieDto movieDto)
        {
            if (movieDto == null)
            {
                return null;
            }

            return new Movie
            {
                Id = movieDto.Id,
                Image = movieDto.Image,
                GenreId= movieDto.GenreId,
                Genre = movieDto.Genre.ToSqlModel(),
                Name = movieDto.Name,
                VideoLink = movieDto.VideoLink,
                IsDeleted = movieDto.IsDeleted
            };
        }

        public static MovieDto ToDto(this Movie movie)
        {
            if (movie == null)
            {
                return null;
            }

            return new MovieDto
            {
                Id = movie.Id,
                Image = movie.Image,
                GenreId = movie.GenreId,
                Genre = movie.Genre.ToDto(),
                Name = movie.Name,
                VideoLink = movie.VideoLink,
                IsDeleted = movie.IsDeleted
            };
        }
    }
}
