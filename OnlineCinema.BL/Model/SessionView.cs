using System;

namespace OnlineCinema.BL.Model
{
    public class SessionView
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public TimeSpan TimeFrom { get; set; }

        public TimeSpan TimeTo { get; set; }
    }
}
