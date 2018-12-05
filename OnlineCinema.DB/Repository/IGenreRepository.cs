using OnlineCinema.DB.DataModels;
using System.Collections.Generic;


namespace OnlineCinema.DB.Repository
{
    public interface IGenreRepository
    {
        int Add(Genre genre);

        void Update(Genre genre);

        void Delete(int id);

        Genre GetDeteils(int id);

        List<Genre> Get();
    }
}
