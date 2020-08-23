using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Library.Client.Generated
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class DocUnionBook
        : IDocUnionBook
    {
        public DocUnionBook(
            int docid, 
            string title, 
            string isbn, 
            System.DateTimeOffset pDate, 
            string pName, 
            global::System.Collections.Generic.IReadOnlyList<global::Library.Client.Generated.ICopy> copy)
        {
            Docid = docid;
            Title = title;
            Isbn = isbn;
            PDate = pDate;
            PName = pName;
            Copy = copy;
        }

        public int Docid { get; }

        public string Title { get; }

        public string Isbn { get; }

        public System.DateTimeOffset PDate { get; }

        public string PName { get; }

        public global::System.Collections.Generic.IReadOnlyList<global::Library.Client.Generated.ICopy> Copy { get; }
    }
}
