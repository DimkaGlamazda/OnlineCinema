

namespace OnlineCinema.BL.Model
{
    public class MovieView
    {
        public int Id { get; set; }

        public int GenreId { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public string VideoLink { get; set; }

        public virtual GenreView Genre { get; set; }
    }
}
