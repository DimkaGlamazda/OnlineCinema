using OnlineCinema.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.BL.Services
{
    public interface IMovieService
    {
        //need MovieDto
        int Add(MovieView movie);

        void Update(MovieView movie);

        void Delete(int id);

        MovieView GetItem(int id);

        List<MovieView> GetAll();
    }

    public class MovieService : IMovieService
    {
        private UnitOfWorkView _uOW = new UnitOfWorkView();

        public int Add(MovieView movie)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<MovieView> GetAll()
        {
            throw new NotImplementedException();
        }

        public MovieView GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(MovieView movie)
        {
            throw new NotImplementedException();
        }
    }

    //del in future
    internal class UnitOfWorkView
    {
        public UnitOfWorkView()
        {
        }
    }
}
