using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Game.Models.GameModels;

namespace Game.Models
{
    public class DamageCheck : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Character)validationContext.ObjectInstance;
            Regex rgx = new Regex(@"^\dd\d$");

            if (!rgx.IsMatch(customer.Damage))
            {
                return new ValidationResult("Damage is required.");
            }
            
            return ValidationResult.Success;
        }
    }
}