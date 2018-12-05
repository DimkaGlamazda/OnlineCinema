using OnlineCinema.BL.Model;
using OnlineCinema.DB.DTOs;

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
                Date = scheduleDto.Date,
                MovieId = scheduleDto.MovieId,
                SessionId = scheduleDto.SessionId,
                Movie = scheduleDto.Movie.ToViewModel(),
                Session = scheduleDto.Session.ToViewModel()
            };
        }

        public static ScheduleDto ToDtoModel(this ScheduleView scheduleView)
        {
            if (scheduleView == null)
            {
                return null;
            }

            return new ScheduleDto
            {
                Id = scheduleView.Id,
                Date = scheduleView.Date,
                MovieId = scheduleView.MovieId,
                SessionId = scheduleView.SessionId,
                Movie = scheduleView.Movie.ToDtoModel(),
                Session = scheduleView.Session.ToDtoModel()
            };
        }
    }

}
