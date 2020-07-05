using Library.Data.Models;
using Library.Shared;

namespace Library.Server.Helpers
{
    public interface ILoginHelper
    {
        public bool ValidateUser(Login credentials);
        public string GenerateToken(Reader reader);
    }
}