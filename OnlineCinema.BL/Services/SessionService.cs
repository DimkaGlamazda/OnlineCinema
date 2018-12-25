﻿using OnlineCinema.BL.Model;
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
        int Add(SessionDto sessionDto);

        void Update(SessionDto sessionDto);

        void Delete(int id);

        SessionDto GetItem(int id);

        List<SessionDto> GetAll();
    }

    public class SessionService : ISessionService
    {
        private UnitOfWork _uOW = new UnitOfWork();

        public int Add(SessionDto sessionDto)
        {
            var sessions = GetAll();
            if (sessions.FirstOrDefault(s => s.Title == sessionDto.Title) == null)
            {
                var session = sessionDto.ToSqlModel();
                _uOW.EFSessionRepository.Add(session);
                _uOW.Save();

                return session.Id;
            }
            else
                throw new Exception("Such item does already exist");
        }

        public void Delete(int id)
        {
            var movie = GetItem(id);
            movie.ToSqlModel().IsDeleted = true;

            _uOW.Save();
        }

        public List<SessionDto> GetAll()
        {
            return _uOW.EFSessionRepository.Get().Where(s=>s.IsDeleted != true).Select(mov => mov.ToDto()).OrderBy(y => y.Title).ToList();
        }

        public SessionDto GetItem(int id)
        {
            var sessions = GetAll();
            if (sessions.FirstOrDefault(s => s.Id == id) != null)
            {
                return _uOW.EFSessionRepository.GetDeteils(id).ToDto();
            }
            else
                throw new Exception("Such item doesn't exist");
        }

        public void Update(SessionDto sessionDto)
        {
            _uOW.EFSessionRepository.Update(sessionDto.ToSqlModel());
            _uOW.Save();
        }
    }
}