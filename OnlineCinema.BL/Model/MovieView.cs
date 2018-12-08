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
        public string Name { get; set; }

        [Required]
        public byte[] Image { get; set; }

        [Required]
        public string VideoLink { get; set; }

        public virtual GenreView Genre { get; set; }
    }
}
