using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace Library.Client.Generated
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface ILibraryClient
    {
        Task<IOperationResult<global::Library.Client.Generated.IGetDocs>> GetDocsAsync(
            Optional<string> search = default,
            Optional<string> after = default,
            Optional<string> before = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::Library.Client.Generated.IGetDocs>> GetDocsAsync(
            GetDocsOperation operation,
            CancellationToken cancellationToken = default);
    }
}
