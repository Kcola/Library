using Library.Server.Models;
using System.Linq;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types.Relay;
using HotChocolate.Types;
// ReSharper disable UnusedMember.Global

namespace Library.Server.Graphql
{
    [Authorize]
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Query
    {
        [UsePaging]
        [UseSelection]
        [UseSorting]
        [UseFiltering]
        public IQueryable<Book> GetBook([Service] libraryContext libraryContext) =>
               libraryContext.Book;

        [UsePaging]
        [UseSelection]
        [UseSorting]
        [UseFiltering]
        public IQueryable<Borrows> GetBorrowed([Service] libraryContext libraryContext) =>
               libraryContext.Borrows;


        [UsePaging]
        [UseSelection]
        [UseSorting]
        [UseFiltering]
        public IQueryable<Reserves> GetReserved([Service] libraryContext libraryContext) =>
               libraryContext.Reserves;

        [UsePaging]
        [UseSelection]
        [UseSorting]
        [UseFiltering]
        public IQueryable<Branch> GetBranch([Service] libraryContext libraryContext) =>
               libraryContext.Branch;

        [UsePaging]
        [UseSelection]
        [UseSorting]
        [UseFiltering]
        public IQueryable<Copy> GetCopy([Service] libraryContext libraryContext) =>
               libraryContext.Copy;
    }
}