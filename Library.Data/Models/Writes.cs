namespace Library.Data.Models
{
    public partial class Writes
    {
        public int Authorid { get; set; }
        public int Docid { get; set; }

        public virtual Author Author { get; set; }
        public virtual Docs Doc { get; set; }
    }
}
