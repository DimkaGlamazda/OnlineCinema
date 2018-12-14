using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace OnlineCinema.BL.Model
{
    
    public class MovieView
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Choose from 1-5 genres for now")]
        public int GenreId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(50, ErrorMessage = "Name shouldn't be more than 50 characters")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Paste your picture here")]
        [DataType(DataType.ImageUrl)]
        public byte[] Image { get; set; }

        [Required]
        [Display(Name = "Enter movie link")]
        [DataType(DataType.Url)]
        public string VideoLink { get; set; }

        public virtual GenreView Genre { get; set; }
    }
}
