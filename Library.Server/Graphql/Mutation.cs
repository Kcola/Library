using System.Threading.Tasks;
using HotChocolate.AspNetCore.Authorization;
using Library.Data.Helpers;
using Library.Data.Models;
using Library.Shared;

// ReSharper disable UnusedMember.Global

namespace Library.Server.Graphql
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Mutation
    {
        private readonly IRepository _repository;

        public Mutation(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<Borrows> Borrowed(BorrowRequest borrowRequest)
        {
            if (!_repository.CopyAvailable(borrowRequest.Copyid))
                return new Borrows();
            var borrowInfo = await _repository.BorrowTransaction(borrowRequest);
            return borrowInfo;
        }
        public async Task<Borrows> Return(int borNumber)
        {
            var borrowInfo = await _repository.ReturnTransaction(borNumber);
            return borrowInfo;
        }
    }
}