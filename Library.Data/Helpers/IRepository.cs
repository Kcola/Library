using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Data.Models;
using Library.Shared;

namespace Library.Data.Helpers
{
    public interface IRepository
    {
        Reader GetReader(string username);
        Users GetUser(string username);
        List<Borrows> GetBorrowed(int readerId);
        Task<bool> AddUser(Users newUser);
        Task<bool> AddReader(Reader newReader);
        Task<Borrows> BorrowTransaction(BorrowRequest borrowRequest);
        Task<Borrows> ReturnTransaction(int borNumber);
        bool CopyAvailable(string copyId);
    }
}
