using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.DB.DTOs
{
     public class ScheduleDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int MovieId { get; set; }

        public int SessionId { get; set; }

        public virtual MovieDto Movie { get; set; }

        public virtual SessionDto Session { get; set; }
    }
}
