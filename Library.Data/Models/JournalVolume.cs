namespace Library.Data.Models
{
    public partial class JournalVolume
    {
        public int Docid { get; set; }
        public int Jvolume { get; set; }
        public int EditorId { get; set; }

        public virtual Document Doc { get; set; }
        public virtual ChiefEditor Editor { get; set; }
    }
}
