using OnlineCinema.DB.DataModels;
using OnlineCinema.DB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.DB.Extensions
{
    public static class SessionConversions
    {
        public static SessionDto ToDto(this Session session)
        {
            if (session == null)
            {
                return null;
            }

            return new SessionDto
            {
                Id = session.Id,
                TimeFrom = session.TimeFrom,
                TimeTo = session.TimeTo,
                Title= session.Title,
                IsDeleted = session.IsDeleted
            };
        }

        public static Session ToSqlModel(this SessionDto sessionDto)
        {
            if (sessionDto == null)
            {
                return null;
            }

            return new Session
            {
                Id = sessionDto.Id,
                TimeFrom = sessionDto.TimeFrom,
                TimeTo = sessionDto.TimeTo,
                Title = sessionDto.Title,
                IsDeleted = sessionDto.IsDeleted
            };
        }
    }
}
