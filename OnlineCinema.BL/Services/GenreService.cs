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
    public interface IGenreService
    {
        int Add(GenreView genre);

        void Update(GenreView genre);

        void Delete(int id);

        GenreView GetItem(int id);

        List<GenreView> GetAll();
    }

    public class GenreService : IGenreService
    {
        private UnitOfWork _uOw = new UnitOfWork();

        public int Add(GenreView genre)
        {
            _uOw.EFGenreRepository.Add(genre.ToDtoModel().ToSqlModel());
            _uOw.Save();
            return genre.Id;
        }

        public void Delete(int id)
        {
            _uOw.EFGenreRepository.Delete(id);
            _uOw.Save();
        }

        public List<GenreView> GetAll()
        {
            return _uOw.EFGenreRepository.Get().Select(c => c.ToDto().ToViewModel()).ToList();
        }

        public GenreView GetItem(int id)
        {
            return _uOw.EFGenreRepository.GetDeteils(id)?.ToDto().ToViewModel();
        }

        public void Update(GenreView genre)
        {
            _uOw.EFGenreRepository.Update(genre.ToDtoModel().ToSqlModel());
            _uOw.Save();
        }
    }
}
