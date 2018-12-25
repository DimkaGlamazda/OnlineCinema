using OnlineCinema.BL.Extensions;
using OnlineCinema.BL.Model;
using OnlineCinema.DB;
using OnlineCinema.DB.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineCinema.BL.Exceptions;

namespace OnlineCinema.BL.Services
{
    public interface IMovieService
    {
        int Add(IMovieViewModel movie, HttpPostedFileBase image);

        void Update(IMovieViewModel movie, HttpPostedFileBase image);

        void Delete(int id);

        MovieView GetItem(int id);

        MovieAdminView GetItemForAdmin(int id);

        List<MovieView> GetAll();

        List<MovieAdminView> GetAllForAdmin();
    }

    public class MovieService : IMovieService
    {
        private UnitOfWork _uOW = new UnitOfWork();

        public int Add(IMovieViewModel movie, HttpPostedFileBase image)
        {

            if (image == null)
                throw new ImageNotFoundException();

            movie.Image = new byte[image.ContentLength];
            image.InputStream.Read(movie.Image, 0, image.ContentLength);

            _uOW.EFMovieRepository.Add(movie.ToDtoModel().ToSqlModel());
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
            return _uOW.EFMovieRepository.Get()
                .Select(m => m.ToDto().ToViewModel())
                .OrderBy(m => m.Name)
                .ToList();
        }

        public List<MovieAdminView> GetAllForAdmin()
        {
            return _uOW.EFMovieRepository.Get()
                .Select(m => m.ToDto().ToAdminViewModel())
                .OrderBy(m => m.Name)
                .ToList();
        }

        public MovieView GetItem(int id)
        {
            return _uOW.EFMovieRepository.GetDeteils(id).ToDto().ToViewModel();
        }

        public MovieAdminView GetItemForAdmin(int id)
        {
            return _uOW.EFMovieRepository.GetDeteils(id).ToDto().ToAdminViewModel();
        }

        public void Update(IMovieViewModel movie, HttpPostedFileBase image)
        {
            var oldMovie = GetItem(movie.Id);

            if(oldMovie.Image == null && image == null)
                throw new ImageNotFoundException();

            if(image == null)
            {
                movie.Image = oldMovie.Image;
            }
            else
            {
                movie.Image = new byte[image.ContentLength];
                image.InputStream.Read(movie.Image, 0, image.ContentLength);
            }

            _uOW.EFMovieRepository.Update(movie.ToDtoModel().ToSqlModel());
            _uOW.Save();
        }
    }
}
