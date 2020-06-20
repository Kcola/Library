using System;
using System.Collections.Generic;

namespace Library.Server.Models
{
    public partial class Writes
    {
        public int Authorid { get; set; }
        public int Docid { get; set; }

        public virtual Author Author { get; set; }
        public virtual Document Doc { get; set; }
    }
}
