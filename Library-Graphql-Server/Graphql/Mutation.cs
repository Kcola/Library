using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using HotChocolate;
using Library.Server.Models;
using Library.Server.ViewModel;
using Microsoft.EntityFrameworkCore.Internal;

namespace Library.Server.Graphql
{
    public abstract class Mutation
    {
        public async Task<Borrows> Borrowed([Service] libraryContext library, BorrowRequest borrowRequest)
        {
            // ReSharper disable once PossibleNullReferenceException
            var available = library.Copy.FirstOrDefault(x=> x.Copyid == borrowRequest.Copyid).Available;
            if(available != null && !(bool)available)
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
    }
}