using OnlineCinema.BL.Model;
using OnlineCinema.DB;
using OnlineCinema.DB.DTOs;
using OnlineCinema.DB.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.BL.Services
{
    public class MockMovieService : IMovieService
    {
        /// <summary>
        /// 1-Adventure
        /// 2-Crime
        /// 3-Action
        /// 4-Animation
        /// 5-Drama
        /// </summary>
        /// 
        private List<MovieDto> _mockMovies = new List<MovieDto>
        {
            new MovieDto ()
            {
                Id = 1,
                GenreId = 1,
                Name = "Back to the Future",
                Image = null,
                VideoLink = "https://www.imdb.com/title/tt0088763/"
            },
            new MovieDto ()
            {
                Id = 2,
                GenreId = 3,
                Name = "The Dark Knight",
                Image = null,
                VideoLink = "https://www.imdb.com/title/tt0468569/"
            },
            new MovieDto ()
            {
                Id = 3,
                GenreId = 2,
                Name = "Pulp Fiction",
                Image = null,
                VideoLink = "https://www.imdb.com/title/tt0110912/"
            },
            new MovieDto ()
            {
                Id = 4,
                GenreId = 5,
                Name = "Slumdog Millionaire",
                Image = null,
                VideoLink = "https://www.imdb.com/title/tt1010048/"
            },
            new MovieDto ()
            {
                Id = 5,
                GenreId = 4,
                Name = "Monsters, Inc.",
                Image = null,
                VideoLink = "https://www.imdb.com/title/tt0198781/"
            },
            new MovieDto ()
            {
                Id = 6,
                GenreId = 5,
                Name = "Bohemian Rhapsodye",
                Image = null,
                VideoLink = "https://www.imdb.com/title/tt1727824/"
            },
            new MovieDto ()
            {
                Id = 7,
                GenreId = 1,
                Name = "The Shape of Water",
                Image = null,
                VideoLink = "https://www.imdb.com/title/tt5580390/"
            },
            new MovieDto ()
            {
                Id = 8,
                GenreId = 2,
                Name = "The Departed",
                Image = null,
                VideoLink = "https://www.imdb.com/title/tt0407887/"
            },
            new MovieDto ()
            {
                Id = 9,
                GenreId = 3,
                Name = "Sherlock Holmes",
                Image = null,
                VideoLink = "https://www.imdb.com/title/tt0988045/"
            },
            new MovieDto ()
            {
                Id = 10,
                GenreId = 4,
                Name = "Zootopia",
                Image = null,
                VideoLink = "https://www.imdb.com/title/tt2948356/"
            }
        };

        public int Add(MovieDto movieDto)
        {
            return 0;
        }

        public void Delete(int id)
        {

        }

        public List<MovieDto> GetAll()
        {
            return _mockMovies.ToList();
        }

        public MovieDto GetItem(int id)
        {
            return _mockMovies[id-1];
        }

        public void Update(MovieDto movieDto)
        {

        }
    }
}
