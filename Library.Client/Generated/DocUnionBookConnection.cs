using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Library.Client.Generated
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class DocUnionBookConnection
        : IDocUnionBookConnection
    {
        public DocUnionBookConnection(
            global::System.Collections.Generic.IReadOnlyList<global::Library.Client.Generated.IDocUnionBookEdge> edges, 
            global::Library.Client.Generated.IPageInfo pageInfo, 
            int totalCount)
        {
            Edges = edges;
            PageInfo = pageInfo;
            TotalCount = totalCount;
        }

        public global::System.Collections.Generic.IReadOnlyList<global::Library.Client.Generated.IDocUnionBookEdge> Edges { get; }

        public global::Library.Client.Generated.IPageInfo PageInfo { get; }

        public int TotalCount { get; }
    }
}
