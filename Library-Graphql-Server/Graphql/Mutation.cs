using System.Net.WebSockets;
using System.Threading.Tasks;
using HotChocolate;
using Library.Server.Models;
using Library.Server.ViewModel;

namespace Library.Server.Graphql
{
    public class Mutation
    {
        public async Task<Borrows> Borrowed([Service] libraryContext library, Borrow borrow)
        {
            var output = new Borrows()
            {
                Readerid = borrow.Readerid,
                Docid = borrow.Docid,
                Libid = borrow.Libid,
                Copyid = borrow.Copyid,
                Duedate = borrow.Duedate,
                Btime = borrow.Btime,
                Position = borrow.Position
            };
            library.Borrows.Add(output);
            await library.SaveChangesAsync();
            return output;
        }
    }
}