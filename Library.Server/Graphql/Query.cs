using System.Linq;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types.Relay;
using HotChocolate.Types;
using Library.Data;
using Library.Data.Models;
using Library.Data.Helpers;

// ReSharper disable UnusedMember.Global

namespace Library.Server.Graphql
{
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

        [UsePaging]
        [UseSelection]
        [UseSorting]
        [UseFiltering]
        public IQueryable<DocUnionBook> GetDoc([Service] LibraryContext libraryContext) =>
               libraryContext.Docs.Join(
                      libraryContext.Book,
            doc => doc.Docid,
            book => book.Docid,
            (doc, book) => new DocUnionBook
            {
                Docid = doc.Docid,
                Isbn = book.Isbn,
                Title = doc.Title,
                PName = doc.Publisher.Pubname,
                PDate = doc.Pdate,
                Borrowed = doc.Borrows,
                Reserved = doc.Reserves,
                Copy = doc.Copy
            }
               );
    }
}