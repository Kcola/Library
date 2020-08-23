namespace Library.Client.Generated
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetDocs
        : IGetDocs
    {
        public GetDocs(
            global::Library.Client.Generated.IDocUnionBookConnection doc)
        {
            Doc = doc;
        }

        public global::Library.Client.Generated.IDocUnionBookConnection Doc { get; }
    }
}
