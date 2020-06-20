using System;
using System.Collections.Generic;

namespace Library.Server.Models
{
    public partial class JournalIssue
    {
        public JournalIssue()
        {
            InvEditor = new HashSet<InvEditor>();
        }

        public int Docid { get; set; }
        public int IssueNo { get; set; }
        public string Scope { get; set; }

        public virtual Document Doc { get; set; }
        public virtual ICollection<InvEditor> InvEditor { get; set; }
    }
}
