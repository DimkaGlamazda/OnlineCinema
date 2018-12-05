using OnlineCinema.DB.DataModels;
using OnlineCinema.DB.DTOs;

namespace OnlineCinema.DB.Extensions
{
    public static class ScheduleConversions
    {
        public static Schedule ToSqlModel(this ScheduleDto scheduleDto)
        {
            if (scheduleDto == null)
            {
                return null;
            }

            return new Schedule
            {
                Id = scheduleDto.Id,
                Date = scheduleDto.Date,
                MovieId = scheduleDto.MovieId,
                SessionId = scheduleDto.SessionId,
                Movie = scheduleDto.Movie.ToSqlModel(),
                Session = scheduleDto.Session.ToSqlModel()
            };
        }

        public static ScheduleDto ToDto(this Schedule schedule)
        {
            if (schedule == null)
            {
                return null;
            }

            return new ScheduleDto
            {
                Id = schedule.Id,
                Date = schedule.Date,
                MovieId = schedule.MovieId,
                SessionId = schedule.SessionId,
                Movie = schedule.Movie.ToDto(),
                Session = schedule.Session.ToDto()
            };
        }
    }
}
