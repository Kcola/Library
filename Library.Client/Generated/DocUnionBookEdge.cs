using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Library.Client.Generated
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class DocUnionBookEdge
        : IDocUnionBookEdge
    {
        public DocUnionBookEdge(
            string cursor, 
            global::Library.Client.Generated.IDocUnionBook node)
        {
            Cursor = cursor;
            Node = node;
        }

        public string Cursor { get; }

        public global::Library.Client.Generated.IDocUnionBook Node { get; }
    }
}
