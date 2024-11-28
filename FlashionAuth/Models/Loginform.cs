using System.ComponentModel.DataAnnotations;

namespace FlashionAuth.Models
{
    public class Loginform
    {
        [Required(ErrorMessage = "UserName is required")]
        public string username {  get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }    
    }
}
