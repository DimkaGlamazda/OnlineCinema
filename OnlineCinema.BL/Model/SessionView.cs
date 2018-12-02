using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.BL.Model
{
    public class SessionView
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public TimeSpan TimeFrom { get; set; }

        public TimeSpan TimeTo { get; set; }

        public bool IsDeleted { get; set; }
    }
}
