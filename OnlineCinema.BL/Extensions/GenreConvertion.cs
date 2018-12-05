using OnlineCinema.BL.Model;
using OnlineCinema.DB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.BL.Extensions
{
    static class GenreConvertion
    {
        public static GenreView ToViewModel(this GenreDto genreDto)
        {
            if (genreDto == null)
            {
                return null;
            }

            return new GenreView
            {
                Id = genreDto.Id,
                Name = genreDto.Name,
                IsDeleted = genreDto.IsDeleted
            };
        }

        public static GenreDto ToDtoModel(this GenreView genreView)
        {
            if (genreView == null)
            {
                return null;
            }

            return new GenreDto
            {
                Id = genreView.Id,
                Name = genreView.Name,
                IsDeleted = genreView.IsDeleted
            };
        }
    }
}
