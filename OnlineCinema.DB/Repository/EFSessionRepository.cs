using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineCinema.DB.DataModels;

namespace OnlineCinema.DB.Repository
{
    public class EFSessionRepository : ISessionRepository
    {
        private OnlineCinemaDataModel _context;

        public EFSessionRepository(OnlineCinemaDataModel context)
        {
            _context = context;
        }

        public int Add(Session session)
        {
            _context.Session.Add(session);

            return session.Id;
        }

        public void Delete(int id)
        {
            var session = GetDeteils(id);

            session.IsDeleted = true;
        }

        public List<Session> Get()
        {
            return _context.Session.ToList();
        }

        public Session GetDeteils(int id)
        {
            return _context.Session.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Session session)
        {
            var OldSession = GetDeteils(session.Id);

            OldSession.TimeFrom = session.TimeFrom;
            OldSession.TimeTo = session.TimeTo;
            OldSession.Title = session.Title;
            OldSession.IsDeleted = session.IsDeleted;
        }
    }
}
