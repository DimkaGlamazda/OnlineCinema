using OnlineCinema.DB.DataModels;
using OnlineCinema.DB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.DB.Extensions
{
    public static class GenreConversions
    {
        public static Genre ToSqlModel(this GenreDto genreDto)
        {
            if (genreDto == null)
            {
                return null;
            }

            return new Genre
            {
                Id = genreDto.Id,
                Name = genreDto.Name,
                IsDeleted = genreDto.IsDeleted
            };
        }

        public static GenreDto ToDto(this Genre genre)
        {
            if (genre == null)
            {
                return null;
            }

            return new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name,
                IsDeleted = genre.IsDeleted
            };
        }
    }
}
