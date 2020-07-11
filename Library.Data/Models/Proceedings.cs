using System;

namespace Library.Data.Models
{
    public partial class Proceedings
    {
        public int Docid { get; set; }
        public DateTime Cdate { get; set; }
        public string Clocation { get; set; }
        public string Ceditor { get; set; }

        public virtual Docs Doc { get; set; }
    }
}
