using OnlineCinema.DB;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OnlineCinema.BL.Attributes
{
    public class GenreNotExists : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _uOw = new UnitOfWork();

            var genre = _uOw.EFGenreRepository.Get().FirstOrDefault(u => u.Name == (string)value);

            if (genre == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Genre is not unique");
            }
        }
    }
}
