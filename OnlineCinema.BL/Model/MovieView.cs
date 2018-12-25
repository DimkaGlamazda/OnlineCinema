using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace OnlineCinema.BL.Model
{
    
    public class MovieView : IMovieViewModel
    {
        public int Id { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(50, ErrorMessage = "Name shouldn't be more than 50 characters")]
        public string Name { get; set; }

        [Display(Name = "Poster")]
        [DataType(DataType.ImageUrl)]
        public byte[] Image { get; set; }

        [Required]
        [Display(Name = "Enter movie link")]
        [RegularExpression(@"(http|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?", ErrorMessage = "Invalid url")]
        public string VideoLink { get; set; }

        public virtual GenreView Genre { get; set; }
    }
}
