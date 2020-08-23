using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace Library.Client.Generated
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class LibraryClient
        : ILibraryClient
    {
        private const string _clientName = "LibraryClient";

        private readonly global::StrawberryShake.IOperationExecutor _executor;

        public LibraryClient(global::StrawberryShake.IOperationExecutorPool executorPool)
        {
            _executor = executorPool.CreateExecutor(_clientName);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::Library.Client.Generated.IGetDocs>> GetDocsAsync(
            global::StrawberryShake.Optional<string> search = default,
            global::StrawberryShake.Optional<string> after = default,
            global::StrawberryShake.Optional<string> before = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new GetDocsOperation
                {
                    Search = search, 
                    After = after, 
                    Before = before
                },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::Library.Client.Generated.IGetDocs>> GetDocsAsync(
            GetDocsOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }
    }
}
