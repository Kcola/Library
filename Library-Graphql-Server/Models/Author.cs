using System;
using System.Collections.Generic;

namespace Library.Server.Models
{
    public partial class Author
    {
        public Author()
        {
            Writes = new HashSet<Writes>();
        }

        public int Authorid { get; set; }
        public string Aname { get; set; }

        public virtual ICollection<Writes> Writes { get; set; }
    }
}
