using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ITS_Web.Models
{
    public class JobApply
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        public string Position { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [Display(Name = "CV")]
        [DataType(DataType.Upload)]
        public IFormFile CvFile { get; set; }
    }

    public class Contact
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        public string Message { get; set; }
    }

    public class SendForm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        public string Position { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [Display(Name = "CV")]
        [DataType(DataType.Upload)]
        public IFormFile CvFile { get; set; }
    }
}