using System;

namespace Library.Data.Models
{
    public partial class Borrows
    {
        public int Bornumber { get; set; }
        public int Readerid { get; set; }
        public int Docid { get; set; }
        public string Copyid { get; set; }
        public int Libid { get; set; }
        public DateTime Btime { get; set; }
        public DateTime? Rtime { get; set; }
        public double Fines { get; set; }
        public DateTime Duedate { get; set; }
        public string Position { get; set; }

        public virtual Docs Doc { get; set; }
        public virtual Branch Lib { get; set; }
        public virtual Reader Reader { get; set; }
    }
}
