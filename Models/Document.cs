using System;
using System.Collections.Generic;

namespace Library.Server.Models
{
    public partial class Document
    {
        public Document()
        {
            Borrows = new HashSet<Borrows>();
            Copy = new HashSet<Copy>();
            InvEditor = new HashSet<InvEditor>();
            JournalIssue = new HashSet<JournalIssue>();
            Reserves = new HashSet<Reserves>();
            Writes = new HashSet<Writes>();
        }

        public int Docid { get; set; }
        public string Title { get; set; }
        public DateTime Pdate { get; set; }
        public int Publisherid { get; set; }

        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<Borrows> Borrows { get; set; }
        public virtual ICollection<Copy> Copy { get; set; }
        public virtual ICollection<InvEditor> InvEditor { get; set; }
        public virtual ICollection<JournalIssue> JournalIssue { get; set; }
        public virtual ICollection<Reserves> Reserves { get; set; }
        public virtual ICollection<Writes> Writes { get; set; }
    }
}
