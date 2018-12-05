using OnlineCinema.DB.DataModels;
using System.Collections.Generic;

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
