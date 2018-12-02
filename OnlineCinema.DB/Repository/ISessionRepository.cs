using OnlineCinema.DB.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.DB.Repository
{
    public interface ISessionRepository
    {
        int Add(Session session);

        void Update(Session session);

        void Delete(int id);

        Session GetDeteils(int id);

        List<Session> Get();
    }
}
