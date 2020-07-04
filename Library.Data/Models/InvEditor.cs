namespace Library.Data.Models
{
    public partial class InvEditor
    {
        public int Docid { get; set; }
        public int IssueNo { get; set; }
        public string Iename { get; set; }

        public virtual Document Doc { get; set; }
        public virtual JournalIssue IssueNoNavigation { get; set; }
    }
}
