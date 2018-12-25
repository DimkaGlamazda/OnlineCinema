using OnlineCinema.BL.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineCinema.BL.Model
{
    public interface IMovieViewModel
    {
        int Id { get; set; }
        int GenreId { get; set; }
        string Name { get; set; }
        byte[] Image { get; set; }
        string VideoLink { get; set; }
        GenreView Genre { get; set; }
    }

    public class MovieAdminView : IMovieViewModel
    {

        public MovieAdminView()
        {
            var genreServcie = new GenreService();
            Genres = genreServcie.GetAll();
        }

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

        public GenreView Genre { get; set; }

        public List<GenreView> Genres { get; }

    }
}
