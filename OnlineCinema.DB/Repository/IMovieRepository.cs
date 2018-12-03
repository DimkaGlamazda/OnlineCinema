using OnlineCinema.DB.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.DB.Repository
{
    public interface IMovieRepository
    {
        int Add(Movie movie);

        void Update(Movie movie);

        void Delete(int id);

        Movie GetDeteils(int id);

        List<Movie> Get();
    }
}
