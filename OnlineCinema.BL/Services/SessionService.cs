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
    public interface ISessionService
    {
        int Add(SessionView sessionView);

        void Update(SessionView sessionView);

        void Delete(int id);

        SessionView GetItem(int id);

        List<SessionView> GetAll();
    }

    public class SessionService : ISessionService
    {
        private UnitOfWork _uOW = new UnitOfWork();

        public int Add(SessionView sessionView)
        {
            var sessions = GetAll();

            if (!sessions.Any(s => s.Title == sessionView.Title))
            {
                var session = sessionView.ToDtoModel().ToSqlModel();
                _uOW.EFSessionRepository.Add(session);
                _uOW.Save();

                return session.Id;
            }
            else
                throw new Exception("Such item does already exist");
        }

        public void Delete(int id)
        {
            var session = GetItem(id);
            session.ToDtoModel().ToSqlModel().IsDeleted = true;
            _uOW.Save();
        }

        public List<SessionView> GetAll()
        {
            return _uOW.EFSessionRepository.Get()
                .Select(mov => mov.ToDto().ToViewModel())
                .OrderBy(y => y.Title)
                .ToList();
        }

        public SessionView GetItem(int id)
        {
            var sessions = GetAll();

            if (!sessions.Any(s => s.Id == id))
            {
                return _uOW.EFSessionRepository
                    .GetDeteils(id)
                    .ToDto().ToViewModel();
            }
            else
                throw new Exception("Such item dosen't exist");
        }

        public void Update(SessionView session)
        {
            _uOW.EFSessionRepository.Update(session.ToDtoModel().ToSqlModel());
            _uOW.Save();
        }
    }
}