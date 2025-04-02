using System.ComponentModel.DataAnnotations;

namespace SpendSmart.Models
{
    public class QuoteRequest
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Your Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Your Phone")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Your Email")]
        public string Email { get; set; }

        [Display(Name = "Your Company")]
        public string Company { get; set; }

        [Required]
        [Display(Name = "Service")]
        public string Service { get; set; }

        [Required]
        [Display(Name = "How to Know Us")]
        public string HowToKnow { get; set; }
    }
}
