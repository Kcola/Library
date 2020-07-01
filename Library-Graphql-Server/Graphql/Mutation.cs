using System;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using Library.Server.Models;
using Library.Server.ViewModel;

namespace Library.Server.Graphql
{
    // ReSharper disable once ClassNeverInstantiated.Global
    [Authorize]
    public class Mutation
    {
        public async Task<Borrows> Borrowed([Service] libraryContext library, BorrowRequest borrowRequest)
        {
            // ReSharper disable once PossibleNullReferenceException
            var available = library.Copy.FirstOrDefault(x => x.Copyid == borrowRequest.Copyid).Available;
            if (available != null && !(bool)available)
                return new Borrows();
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
            await library.Borrows.AddAsync(borrowTransaction);
            var copy = library.Copy.FirstOrDefault(x => x.Copyid == borrowTransaction.Copyid);
            if (copy != null) copy.Available = false;
            await library.SaveChangesAsync();
            return borrowTransaction;
        }
        public async Task<Borrows> Return([Service] libraryContext library, int borNumber)
        {
            // ReSharper disable once PossibleNullReferenceException
            var borrowed = library.Borrows.FirstOrDefault(x => x.Bornumber == borNumber);
            if (borrowed == null || borrowed.Rtime != null)
                return null;
            else
            {
                borrowed.Rtime = DateTime.Now;
                var copy = library.Copy.FirstOrDefault(x => x.Copyid == borrowed.Copyid);
                if (copy != null) copy.Available = true;
                await library.SaveChangesAsync();
                return borrowed;
            }
        }
    }
}