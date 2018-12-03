using OnlineCinema.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.BL.Extensions
{
    public static class ScheduleConvertion
    {
        public static ScheduleView ToViewModel(ScheduleDto scheduleDto)
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
        public static ScheduleDto ToDtoModel(ScheduleView scheduleView)
        {
            if (scheduleView == null)
            {
                return null;
            }

            return new ScheduleView
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

    //del two classes after merge
    public class ScheduleDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int MovieId { get; set; }

        public int SessionId { get; set; }

        public virtual MovieDto Movie { get; set; }

        public virtual SessionDto Session { get; set; }
    }

    public class SessionDto
    {
    }
}
