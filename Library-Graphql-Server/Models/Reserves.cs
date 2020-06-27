using System;
using System.Collections.Generic;

namespace Library.Server.Models
{
    public partial class Reserves
    {
        public int Resnumber { get; set; }
        public int Readerid { get; set; }
        public int Docid { get; set; }
        public string Copyid { get; set; }
        public int Libid { get; set; }
        public DateTime Dtime { get; set; }
        public string Position { get; set; }
        public DateTime? Ptime { get; set; }

        public virtual Document Doc { get; set; }
        public virtual Branch Lib { get; set; }
        public virtual Reader Reader { get; set; }
    }
}
