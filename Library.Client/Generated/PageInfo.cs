namespace Library.Client.Generated
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class PageInfo
        : IPageInfo
    {
        public PageInfo(
            string endCursor, 
            bool hasNextPage, 
            bool hasPreviousPage, 
            string startCursor)
        {
            EndCursor = endCursor;
            HasNextPage = hasNextPage;
            HasPreviousPage = hasPreviousPage;
            StartCursor = startCursor;
        }

        public string EndCursor { get; }

        public bool HasNextPage { get; }

        public bool HasPreviousPage { get; }

        public string StartCursor { get; }
    }
}
