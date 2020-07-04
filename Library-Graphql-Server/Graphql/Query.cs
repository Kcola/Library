using System.Linq;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types.Relay;
using HotChocolate.Types;
using Library.Data;
using Library.Data.Models;

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
        public IQueryable<Book> GetBook([Service] LibraryContext libraryContext) =>
               libraryContext.Book;

        [UsePaging]
        [UseSelection]
        [UseSorting]
        [UseFiltering]
        public IQueryable<Borrows> GetBorrowed([Service] LibraryContext libraryContext) =>
               libraryContext.Borrows;


        [UsePaging]
        [UseSelection]
        [UseSorting]
        [UseFiltering]
        public IQueryable<Reserves> GetReserved([Service] LibraryContext libraryContext) =>
               libraryContext.Reserves;

        [UsePaging]
        [UseSelection]
        [UseSorting]
        [UseFiltering]
        public IQueryable<Branch> GetBranch([Service] LibraryContext libraryContext) =>
               libraryContext.Branch;

        [UsePaging]
        [UseSelection]
        [UseSorting]
        [UseFiltering]
        public IQueryable<Copy> GetCopy([Service] LibraryContext libraryContext) =>
               libraryContext.Copy;
    }
}