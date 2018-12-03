using OnlineCinema.DB.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
