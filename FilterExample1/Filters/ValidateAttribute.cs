using System.ComponentModel.DataAnnotations;

namespace FilterExample1.Filters
{
    public class ValidateAttribute : ValidationAttribute
    {
        public bool checkFuture { get; set; } = false;

        protected override ValidationResult IsValid(object? v, ValidationContext context)
        {
                if(v is DateTime dt)
                {
                    if(checkFuture && dt < DateTime.Now)
                    {
                        return new ValidationResult(ErrorMessage ?? "Date must be a future date");
                    }

                    if (!checkFuture && dt > DateTime.Now)
                    {
                        return new ValidationResult(ErrorMessage ?? "Date can not be a future date");
                    }
                }
            return ValidationResult.Success;
            
        }
    }
}
