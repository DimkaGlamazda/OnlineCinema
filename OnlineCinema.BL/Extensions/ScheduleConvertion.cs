using OnlineCinema.BL.Model;
using OnlineCinema.DB.DTOs;
using System;

namespace OnlineCinema.BL.Extensions
{
    public static class ScheduleConvertion
    {
        public static ScheduleView ToViewModel(this ScheduleDto scheduleDto)
        {
            if (scheduleDto == null)
            {
                return null;
            }

            return new ScheduleView
            {
                Id = scheduleDto.Id,
                Date = scheduleDto.Date.ToString("dd/MM/yyyy"),
                MovieId = scheduleDto.MovieId,
                SessionId = scheduleDto.SessionId,
                Movie = scheduleDto.Movie.ToViewModel(),
                Session = scheduleDto.Session.ToViewModel()
            };
        }

        public static ScheduleAdminView ToAdminViewModel(this ScheduleDto scheduleDto)
        {
            if (scheduleDto == null)
            {
                return null;
            }

            return new ScheduleAdminView
            {
                Id = scheduleDto.Id,
                Date = scheduleDto.Date.ToString("dd/MM/yyyy"),
                MovieId = scheduleDto.MovieId,
                SessionId = scheduleDto.SessionId,
                Movie = scheduleDto.Movie.ToViewModel(),
                Session = scheduleDto.Session.ToViewModel()
            };
        }

        public static ScheduleDto ToDtoModel(this IScheduleView scheduleView)
        {
            if (scheduleView == null)
            {
                return null;
            }

            return new ScheduleDto
            {
                Id = scheduleView.Id,
                Date = Convert.ToDateTime(scheduleView.Date),
                MovieId = scheduleView.MovieId,
                SessionId = scheduleView.SessionId,
                Movie = scheduleView.Movie.ToDtoModel(),
                Session = scheduleView.Session.ToDtoModel()
            };
        }
    }

}
