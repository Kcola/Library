using System.Collections.Generic;

namespace Library.Data.Models
{
    public partial class Reader
    {
        public Reader()
        {
            Borrows = new HashSet<Borrows>();
            Reserves = new HashSet<Reserves>();
        }

        public int Readerid { get; set; }
        public string Email { get; set; }
        public string Rtype { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }

        public virtual Users Users { get; set; }
        public virtual ICollection<Borrows> Borrows { get; set; }
        public virtual ICollection<Reserves> Reserves { get; set; }
    }
}
