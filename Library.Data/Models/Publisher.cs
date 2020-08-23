using System.Collections.Generic;

namespace Library.Data.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Document = new HashSet<Document>();
        }

        public int Publisherid { get; set; }
        public string Pubname { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }

        public virtual ICollection<Document> Document { get; set; }
    }
}
