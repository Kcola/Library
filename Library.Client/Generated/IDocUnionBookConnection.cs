using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Library.Client.Generated
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IDocUnionBookConnection
    {
        global::System.Collections.Generic.IReadOnlyList<global::Library.Client.Generated.IDocUnionBookEdge> Edges { get; }

        global::Library.Client.Generated.IPageInfo PageInfo { get; }

        int TotalCount { get; }
    }
}
