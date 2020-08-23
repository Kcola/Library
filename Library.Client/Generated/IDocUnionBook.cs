using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Library.Client.Generated
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IDocUnionBook
    {
        int Docid { get; }

        string Title { get; }

        string Isbn { get; }

        System.DateTimeOffset PDate { get; }

        string PName { get; }

        global::System.Collections.Generic.IReadOnlyList<global::Library.Client.Generated.ICopy> Copy { get; }
    }
}
