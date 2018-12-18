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
    public interface IMovieService
    {
        int Add(MovieDto movieDto);

        void Update(MovieDto movieDto);

        void Delete(int id);

        MovieDto GetItem(int id);

        List<MovieDto> GetAll();
    }

    public class MovieService : IMovieService
    {
        private UnitOfWork _uOW = new UnitOfWork();

        public int Add(MovieDto movieDto)
        {
            var movie = movieDto.ToSqlModel();
            _uOW.EFMovieRepository.Add(movie);
            _uOW.Save();

            return movie.Id;
        }

        public void Delete(int id)
        {
            var movie = GetItem(id);
            //movie.IsDeleted = true;
            _uOW.Save();
        }

        public List<MovieDto> GetAll()
        {
            return _uOW.EFMovieRepository.Get().Select(mov => mov.ToDto()).ToList();
        }

        public MovieDto GetItem(int id)
        {
            return _uOW.EFMovieRepository.GetDeteils(id).ToDto();
        }

        public void Update(MovieDto movieDto)
        {
            var movie = movieDto.ToSqlModel();
            _uOW.EFMovieRepository.Update(movie);
            _uOW.Save();
        }
    }
}
