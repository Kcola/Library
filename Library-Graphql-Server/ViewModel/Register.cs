using System.Text.RegularExpressions;

namespace Library.Server.ViewModel
{
    public class Register
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string Role { get; set; }
        public string Type { get; set; }

        public bool AreValid()
        {
            var alphaNumeric = new Regex("^[a-zA-Z0-9]*$");
            if (!alphaNumeric.IsMatch(Username))
                return false;
            return Password.Length >= 2;
        }
    }
}
