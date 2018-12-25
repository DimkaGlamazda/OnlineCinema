using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.DB.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }

        public int GenreId { get; set; }

        public string Name { get; set; }

        [Required]
        public byte[] Image { get; set; }

        public string VideoLink { get; set; }

        public virtual GenreDto Genre { get; set; }
    }
}
