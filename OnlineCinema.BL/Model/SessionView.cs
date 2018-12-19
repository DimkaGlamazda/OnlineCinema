using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineCinema.BL.Model
{
    public class SessionView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field Title is obligatory")]
        [StringLength(100, ErrorMessage = "Please enter at least 3 letters!", MinimumLength = 3)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Field TimeFrom is obligatory")]
        [Display(Name = "Time From")]
        public TimeSpan TimeFrom { get; set; }

        [Required(ErrorMessage = "Field TimeTo is obligatory")]
        [Display(Name = "Time To")]
        public TimeSpan TimeTo { get; set; }
    }
}
