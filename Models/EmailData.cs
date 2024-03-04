using System.ComponentModel.DataAnnotations;

namespace ITS_Web.Models
{
    public class JobApply
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [Display(Name = "CV")]
        [DataType(DataType.Upload)]
        public IFormFile CvFile { get; set; }
    }

    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
    }

    public class SendForm
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public IFormFile CvFile { get; set; }
    }
}