using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Library.Client.Generated
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IPageInfo
    {
        string EndCursor { get; }

        bool HasNextPage { get; }

        bool HasPreviousPage { get; }

        string StartCursor { get; }
    }
}
