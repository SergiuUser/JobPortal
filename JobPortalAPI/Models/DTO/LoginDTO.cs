using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JobPortalAPI.Models.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
