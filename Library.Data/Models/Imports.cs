using System;

namespace Library.Data.Models
{
    public partial class Imports
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public double AverageRating { get; set; }
        public long Isbn { get; set; }
        public long Isbn13 { get; set; }
        public string LanguageCode { get; set; }
        public short NumPages { get; set; }
        public int RatingsCount { get; set; }
        public int TextReviewsCount { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Publisher { get; set; }
    }
}
