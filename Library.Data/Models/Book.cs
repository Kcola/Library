namespace Library.Data.Models
{
    public partial class Book
    {
        public int Docid { get; set; }
        public string Isbn { get; set; }
        public string Genre { get; set; }

        public virtual Docs Doc { get; set; }
    }
}
