using System;
using System.Collections.Generic;

namespace Library.Server.Models
{
    public partial class Branch
    {
        public Branch()
        {
            Borrows = new HashSet<Borrows>();
            Copy = new HashSet<Copy>();
            Reserves = new HashSet<Reserves>();
        }

        public int Libid { get; set; }
        public string Lname { get; set; }
        public string Llocation { get; set; }

        public virtual ICollection<Borrows> Borrows { get; set; }
        public virtual ICollection<Copy> Copy { get; set; }
        public virtual ICollection<Reserves> Reserves { get; set; }
    }
}
