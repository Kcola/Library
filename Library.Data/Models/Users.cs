namespace Library.Data.Models
{
    public partial class Users
    {
        public int Readerid { get; set; }
        public string Username { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual Reader Reader { get; set; }
    }
}
