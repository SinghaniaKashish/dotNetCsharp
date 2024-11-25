using CarRentalSystem.Filters;
using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models
{
 //Id, Make, Model, Year, PricePerDay, IsAvailable(boolean indicating availability)
    public class Car
    {
        public string Id { get; set; }


        //make
        [Required (ErrorMessage = "Make is reqired")]
        [StringLength (50, ErrorMessage ="Make length should be between 1 to 50 ")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Make should contain only alphanumeric characters and spaces.")]
        public string Make { get; set; }


        //model
        [Required(ErrorMessage = "Model is reqired")]
        [StringLength(100, ErrorMessage = "Model length should be between 1 to 100 ")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Model should contain only alphanumeric characters and spaces.")]
        public string Model { get; set; }


        //year
        [Required(ErrorMessage = "Year is required")]
        [ValidateYear(1900)]
        //[Range(1900, 2025, ErrorMessage = "Year should be betwwen 1900 to 2025")]
        public int Year { get; set; }


        //pricePerDay
        [Required(ErrorMessage = "Price per day is required")]
        [Range(1, 100000, ErrorMessage ="Price should be betwwen 1 to 1lakh")]
        [DataType(DataType.Currency)]
        public decimal PricePerDay { get; set; }


        //status
        [Required(ErrorMessage = "Availability Status is reqired")]
        public bool IsAvailable {  get; set; }
    }
}
