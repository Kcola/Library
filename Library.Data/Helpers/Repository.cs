using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data.Models;
using Library.Shared;
using Reader = Library.Data.Models.Reader;

namespace Library.Data.Helpers
{
    public class Repository : IRepository
    {
        private readonly LibraryContext _library;

        public Repository(LibraryContext library)
        {
            _library = library;
        }

        public bool CopyAvailable(string copyId)
        {
            return _library.Copy.FirstOrDefault(x => x.Copyid == copyId)?.Available != null;
        }

        public Reader GetReader(string username)
        {
            return _library.Reader.FirstOrDefault(x => x.Users.Username == username);
        }
        public Users GetUser(string username)
        {
            return _library.Users.FirstOrDefault(x => x.Username == username);
        }

        public async Task<bool> AddUser(Users newUser)
        {
            await _library.Users.AddAsync(newUser);
            var affectedRows = await _library.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<bool> AddReader(Reader newReader)
        {
            await _library.Reader.AddAsync(newReader);
            var affectedRows = await _library.SaveChangesAsync();
            return affectedRows > 0;
        }

        public async Task<Borrows> BorrowTransaction(BorrowRequest borrowRequest)
        {
            var borrowTransaction = new Borrows()
            {
                Readerid = borrowRequest.Readerid,
                Docid = borrowRequest.Docid,
                Libid = borrowRequest.Libid,
                Copyid = borrowRequest.Copyid,
                Duedate = borrowRequest.Duedate,
                Btime = borrowRequest.Btime,
                Position = borrowRequest.Position
            };
            await _library.Borrows.AddAsync(borrowTransaction);
            var copy = _library.Copy.FirstOrDefault(x => x.Copyid == borrowTransaction.Copyid);
            if (copy != null) copy.Available = false;
            await _library.SaveChangesAsync();
            return borrowTransaction;
        }

        public async Task<Borrows> ReturnTransaction(int borNumber)
        {
            var borrowed = _library.Borrows.FirstOrDefault(x => x.Bornumber == borNumber);
            if (borrowed == null || borrowed.Rtime != null)
                return null;
            else
            {
                borrowed.Rtime = DateTime.Now;
                var copy = _library.Copy.FirstOrDefault(x => x.Copyid == borrowed.Copyid);
                if (copy != null) copy.Available = true;
                await _library.SaveChangesAsync();
                return borrowed;
            }
        }

        public List<Borrows> GetBorrowed(int readerId)
        {
            return _library.Borrows.Where(x => x.Readerid == readerId && x.Rtime == null).ToList();
        }
    }
}
