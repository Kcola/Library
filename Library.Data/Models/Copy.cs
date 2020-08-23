namespace Library.Data.Models
{
    public partial class Copy
    {
        public int Docid { get; set; }
        public string Copyid { get; set; }
        public int Libid { get; set; }
        public bool? Available { get; set; }

        public virtual Document Doc { get; set; }
        public virtual Branch Lib { get; set; }
    }
}
