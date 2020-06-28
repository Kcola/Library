using Library.Server.Models;

namespace Library.Server.Helpers
{
    public interface IRepository
    {
        Reader GetReader(string username);
        Users GetUser(string username);
    }
}
