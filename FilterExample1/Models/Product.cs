using FilterExample1.Filters;
using System.ComponentModel.DataAnnotations;

namespace FilterExample1.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength =5, ErrorMessage = "Name length should be between 5 and 100")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name should only alphabets and space")]
        public string Name { get; set; }

        [StringLength(500, MinimumLength = 10, ErrorMessage = "Description length should be between 10 and 500")]

        public string Description { get; set; }
        public string Category { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100000000, ErrorMessage ="Price must be positive")]
        [DataType(DataType.Currency)]

        public decimal Price { get; set; }
        [Required(ErrorMessage = "Mfd is required")]
        [DataType(DataType.Date)]
        [Validate(checkFuture = false)]

        public DateTime ManufactureDate { get; set; }
        [Required(ErrorMessage = "Expdate is required")]
        [DataType(DataType.Date)]
        [Validate(checkFuture = true, ErrorMessage = "Date must be future date")]
        public DateTime ExpiryDate { get; set; }

        [EmailAddress(ErrorMessage = "invaild Email Format")]
        public string Email { get; set; }

    }
}
