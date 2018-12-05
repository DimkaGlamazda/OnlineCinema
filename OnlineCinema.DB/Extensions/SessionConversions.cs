using OnlineCinema.DB.DataModels;
using OnlineCinema.DB.DTOs;

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
                Title= session.Title
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
                Title = sessionDto.Title
            };
        }
    }
}
