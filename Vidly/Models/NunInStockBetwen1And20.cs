using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class NunInStockBetwen1And20 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            if (movie.NumberInStock > 20 || movie.NumberInStock <= 0)
                return new ValidationResult("The Number in Stock must be between 1 and 20");

            return ValidationResult.Success;
        }
    }
}