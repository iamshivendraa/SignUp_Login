namespace SignUpLogin.Models
{
    public class LoginSignUpModel
    {
        public string? FirstName {  get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? Email {  get; set; }
        public string? Gender { get; set; }
        public List<string> Hobbies {  get; set; }

        public SourceOfIncome sourceOfIncome { get; set; }

        public int? Income {  get; set; }

        public int? Age {  get; set; }

        public string? Bio { get; set; }

        public enum SourceOfIncome
        {
            Employed,Self_Employed,Freelancer,Other
        }

    }
}
