using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contact_Form.Models
{
    public class ContactFormViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        [MaxLength(15)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Subject")]
        [MaxLength(255)]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Message")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}
