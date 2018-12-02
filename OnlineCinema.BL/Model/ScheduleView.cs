using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.BL.Model
{
    public class ScheduleView
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int MovieId { get; set; }

        public int SessionId { get; set; }

        public virtual MovieView Movie { get; set; }

        public virtual SessionView Session { get; set; }
    }
}
