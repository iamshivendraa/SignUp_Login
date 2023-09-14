using System.ComponentModel.DataAnnotations;

namespace SignUpLogin.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Email is required.")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is Required.")]
        public string Password { get; set; } = null!;
    }
}
