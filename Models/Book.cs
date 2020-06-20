using System;
using System.Collections.Generic;

namespace Library.Server.Models
{
    public partial class Book
    {
        public int Docid { get; set; }
        public string Isbn { get; set; }
        public string Genre { get; set; }

        public virtual Document Doc { get; set; }
    }
}
