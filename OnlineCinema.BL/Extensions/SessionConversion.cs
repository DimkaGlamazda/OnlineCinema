using OnlineCinema.BL.Model;
using OnlineCinema.DB.DTOs;

namespace OnlineCinema.BL.Extensions
{
    public static class SessionConversion
    {
        public static SessionDto ToDtoModel(this SessionView sessionView)
        {
            if (sessionView == null)
            {
                return null;
            }

            return new SessionDto
            {
                Id = sessionView.Id,
                Title = sessionView.Title,
                TimeFrom = sessionView.TimeFrom,
                TimeTo = sessionView.TimeTo
            };
        }

        public static SessionView ToViewModel(this SessionDto sessionDto)
        {
            if (sessionDto == null)
            {
                return null;
            }

            return new SessionView
            {
                Id = sessionDto.Id,
                Title = sessionDto.Title,
                TimeFrom = sessionDto.TimeFrom,
                TimeTo = sessionDto.TimeTo
            };
        }
    }
}
