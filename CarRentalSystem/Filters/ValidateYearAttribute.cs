using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Filters
{
    public class ValidateYearAttribute: ValidationAttribute
    {
        private readonly int minyear;
        public ValidateYearAttribute(int minyear)
        {
            minyear = minyear;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is int year)
            {
                if(year >= minyear &&  year <= DateTime.Now.Year)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessage ?? $"Date Must be between {minyear} and current year");
        }
    }
}
