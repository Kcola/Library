using System;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using Library.Server.Helpers;
using Library.Server.Models;
using Library.Server.ViewModel;

namespace Library.Server.Graphql
{
    // ReSharper disable once ClassNeverInstantiated.Global
    [Authorize]
    public class Mutation
    {
        private readonly IRepository _repository;

        public Mutation(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<Borrows> Borrowed([Service] libraryContext library, BorrowRequest borrowRequest)
        {
            if (_repository.IsAvailable(borrowRequest.Copyid))
                return new Borrows();
            var borrowInfo = await _repository.BorrowTransaction(borrowRequest);
            return borrowInfo;
        }
        public async Task<Borrows> Return([Service] libraryContext library, int borNumber)
        {
            var borrowInfo = await _repository.ReturnTransaction(borNumber);
            return borrowInfo;
        }
    }
}