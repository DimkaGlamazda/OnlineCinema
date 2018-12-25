using OnlineCinema.BL.Attributes;
using OnlineCinema.BL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.BL.Model
{
    public interface IScheduleView
    {
        int Id { get; set; }

        string Date { get; set; }

        int MovieId { get; set; }

        int SessionId { get; set; }

        MovieView Movie { get; set; }

        SessionView Session { get; set; }
    }

    public class ScheduleAdminView : IScheduleView
    {
        public ScheduleAdminView()
        {
            var movieService = new MovieService();
            MoviesList = movieService.GetAll();

            var sessionService = new SessionService();
            SessionList = sessionService.GetAll();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        [IsMoreThenCurrentDate]
        public string Date { get; set; }

        [Required(ErrorMessage = "Required field")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Required field")]
        public int SessionId { get; set; }

        public virtual MovieView Movie { get; set; }

        public virtual SessionView Session { get; set; }

        public List<MovieView> MoviesList { get; set; }

        public List<SessionView> SessionList { get; set; }
    }
}
