using System;
using System.Collections.Generic;
using HotChocolate.Types;
using Library.Data.Models;

namespace Library.Data.Helpers
{
    public class DocUnionBook
    {
        public int Docid { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string PName { get; set; }
        public DateTime PDate { get; set; }
        public ICollection<Borrows> Borrowed { get; set; }
        public ICollection<Reserves> Reserved { get; set; }
        [UseFiltering]
        public ICollection<Copy> Copy { get; set; }
    }
}