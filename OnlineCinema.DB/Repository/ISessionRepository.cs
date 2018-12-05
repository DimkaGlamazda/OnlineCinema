using OnlineCinema.DB.DataModels;
using System.Collections.Generic;

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
