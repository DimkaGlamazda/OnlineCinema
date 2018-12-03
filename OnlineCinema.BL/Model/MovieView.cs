using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.BL.Model
{
    public class MovieView
    {
        public int Id { get; set; }

        public int GenreId { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public string VideoLink { get; set; }

        public bool IsDeleted { get; set; }

        public virtual GenreView Genre { get; set; }
    }
}
