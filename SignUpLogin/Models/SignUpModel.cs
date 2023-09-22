using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace SignUpLogin.Models
{
    public class SignUpModel
    {
        [Key]
        public int Id { get; set; }

        //First Name
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "First Name should contain only letters.")]
        [DisplayName("First Name*")]
        public string? FirstName {  get; set; }

        //Last Name
        [Required(ErrorMessage ="Last Name is required.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Last Name should contain only letters.")]
        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        //Email
        [Required(ErrorMessage ="Email is required.")]
        [EmailAddress(ErrorMessage ="Invalid email address.")]
        [DisplayName("Email*")]
        public string? Email { get; set; }

        //Password
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(12, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=]).*$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        [DisplayName("Password*")]
        public string? Password { get; set; }

        //Confirm Password
        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "The password and confirm password do not match.")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password*")]

        public string? ConfirmPassword { get; set; }
        
        //Gender
        public string? Gender { get; set; }

        //Music
        public bool Music {  get; set; }

        //Sports
        public bool Sports {  get; set; }

        //Travel
        public bool Travel {  get; set; }

        //Movies
        public bool Movies {  get; set; }

        //Source of Income
        public SourceOfIncome sourceOfIncome { get; set; }

        //Income
        public int? Income {  get; set; }

        //Age
        [Required(ErrorMessage ="Age is required.")]
        [DisplayName("Age*")]
        public int? Age {  get; set; }

        //Bio
        public string? Bio { get; set; }

        public bool IsDeleted {  get; set; }



        //Source of Income enum
        public enum SourceOfIncome
        {
            Employed,
            Self_Employed,
            Freelancer,
            Other
        }

    }
}
