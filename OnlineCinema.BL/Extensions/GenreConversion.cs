using OnlineCinema.BL.Model;
using OnlineCinema.DB.DTOs;

namespace OnlineCinema.BL.Extensions
{
    public static class GenreConversion
    {
        public static GenreDto ToDtoModel(this GenreView genreView)
        {
            if (genreView == null)
            {
                return null;
            }

            return new GenreDto
            {
                Id = genreView.Id,
                Name = genreView.Name
            };
        }

        public static GenreView ToViewModel(this GenreDto genreDto)
        {
            if (genreDto == null)
            {
                return null;
            }

            return new GenreView
            {
                Id = genreDto.Id,
                Name = genreDto.Name
            };
        }
    }
}
