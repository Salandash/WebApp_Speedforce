using System.ComponentModel.DataAnnotations;

namespace WebApp_Speedforce.Models
{
    public class UserLoginViewModel
    {
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; }
    }
}