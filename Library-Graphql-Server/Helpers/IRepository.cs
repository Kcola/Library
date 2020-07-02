using System.Threading.Tasks;
using Library.Server.Models;
using Library.Server.ViewModel;

namespace Library.Server.Helpers
{
    public interface IRepository
    {
        Reader GetReader(string username);
        Users GetUser(string username);
        Task<bool> AddUser(Users newUser);
        Task<bool> AddReader(Reader newReader);
        Task<Borrows> BorrowTransaction(BorrowRequest borrowRequest);
        Task<Borrows> ReturnTransaction(int borNumber);
        bool IsAvailable(string copyId);
    }
}
