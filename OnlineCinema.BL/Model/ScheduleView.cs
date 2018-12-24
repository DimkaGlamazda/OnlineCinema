using OnlineCinema.BL.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.BL.Model
{
    public class ScheduleView
    {
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
    }
}
