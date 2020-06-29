using System.Linq;
using Library.Server.Models;

namespace Library.Server.Helpers
{
    public class Repository : IRepository
    {
        private readonly libraryContext _library;

        public Repository(libraryContext library)
        {
            _library = library;
        }

        public Reader GetReader(string username)
        {
            return _library.Reader.FirstOrDefault(x => x.Users.Username == username);
        }
        public Users GetUser(string username)
        {
            return _library.Users.FirstOrDefault(x => x.Username == username);
        }
    }
}
