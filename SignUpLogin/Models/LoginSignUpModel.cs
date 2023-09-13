using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace SignUpLogin.Models
{
    public class LoginSignUpModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name *")]
        public string? FirstName {  get; set; }
        [Required]
        [DisplayName("Last Name*")]
        public string? LastName { get; set; }
        [Required]
        [DisplayName("Password*")]
        public string? Password { get; set; }
        [DisplayName("Confirm Password*")]
        public string? ConfirmPassword { get; set; }
        [Required]
        [DisplayName("Email*")]
        public string? Email {  get; set; }
        public string? Gender { get; set; }
        public bool Music {  get; set; }
        public bool Sports {  get; set; }
        public bool Travel {  get; set; }
        public bool Movies {  get; set; }
        [Required]
        [DisplayName("Source of Income")]
        public SourceOfIncome sourceOfIncome { get; set; }


        public int? Income {  get; set; }

        public int? Age {  get; set; }

        public string? Bio { get; set; }

        public enum SourceOfIncome
        {
            Employed,
            Self_Employed,
            Freelancer,
            Other
        }

    }
}
