using System.ComponentModel.DataAnnotations;

namespace FlashionAuth.Models
{
    public class Signupform
    {
        [Required(ErrorMessage ="Name is required")]
        public string name {  get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public string username {  get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }  
    }
}
