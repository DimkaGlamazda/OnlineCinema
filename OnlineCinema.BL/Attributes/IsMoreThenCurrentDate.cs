using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.BL.Attributes
{
    public class IsMoreThenCurrentDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            DateTime inputDate = Convert.ToDateTime(value);
            DateTime currentDate = DateTime.Now;
            int result = DateTime.Compare(inputDate, currentDate);

            if(result >= 0)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("You can't use this date");
            }
        }
    }
}
