using OnlineCinema.BL.Extensions;
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
        int Add(MovieView movieDto);

        void Update(MovieView movieDto);

        void Delete(int id);

        MovieView GetItem(int id);

        List<MovieView> GetAll();
    }

    public class MovieService : IMovieService
    {
        private UnitOfWork _uOW = new UnitOfWork();

        public int Add(MovieView model)
        {
            var movie = model.ToDtoModel().ToSqlModel();
            _uOW.EFMovieRepository.Add(movie);
            _uOW.Save();

            return movie.Id;
        }

        public void Delete(int id)
        {
            _uOW.EFMovieRepository.Delete(id);
            _uOW.Save();
        }

        public List<MovieView> GetAll()
        {
            return _uOW.EFMovieRepository.Get().Select(mov => mov.ToDto().ToViewModel()).ToList();
        }

        public MovieView GetItem(int id)
        {
            return _uOW.EFMovieRepository.GetDeteils(id).ToDto().ToViewModel();
        }

        public void Update(MovieView model)
        {
            var movie = model.ToDtoModel().ToSqlModel();
            _uOW.EFMovieRepository.Update(movie);
            _uOW.Save();
        }
    }
}
