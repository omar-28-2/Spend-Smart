using System.ComponentModel.DataAnnotations;

namespace SpendSmart.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Value must be greater than 0.")]
        public decimal value { get; set; }

        [Required]
        [StringLength(100,ErrorMessage = "Description cannot exceed 100 characters.")]
        public string? description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Action")]
        [DateRange(2000)]
        public DateTime DateOfAction { get; set; }
    }
}
