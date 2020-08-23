using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Library.Client.Generated
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Copy
        : ICopy
    {
        public Copy(
            string copyid)
        {
            Copyid = copyid;
        }

        public string Copyid { get; }
    }
}
