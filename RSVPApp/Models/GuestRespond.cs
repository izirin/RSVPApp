using System.ComponentModel.DataAnnotations;
namespace RSVPApp.Models
{
    public class GuestRespond
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please specify whether you will attend")]
        public bool? Attend { get; set; }

    }
}
