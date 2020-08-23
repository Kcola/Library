using Library.Shared;
using Reader = Library.Data.Models.Reader;

namespace Library.Server.Helpers
{
    public interface ILoginHelper
    {
        public bool ValidateUser(Login credentials);
        public string GenerateToken(Reader reader);
    }
}