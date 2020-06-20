using System;
using System.Collections.Generic;

namespace Library.Server.Models
{
    public partial class Proceedings
    {
        public int Docid { get; set; }
        public DateTime Cdate { get; set; }
        public string Clocation { get; set; }
        public string Ceditor { get; set; }

        public virtual Document Doc { get; set; }
    }
}
