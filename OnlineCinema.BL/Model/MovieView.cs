using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace OnlineCinema.BL.Model
{
    
    public class MovieView
    {
        public int Id { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Paste your picture here")]
        public byte[] Image { get; set; }

        [Required]
        [Display(Name = "Enter link to your movie")]
        public string VideoLink { get; set; }

        public virtual GenreView Genre { get; set; }
    }
}
