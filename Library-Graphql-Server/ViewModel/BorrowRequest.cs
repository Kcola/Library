using System;

namespace Library.Server.ViewModel
{
    public class BorrowRequest
    {
                public int Readerid { get; set; }
                public int Docid { get; set; }
                public string Copyid { get; set; }
                public int Libid { get; set; }
                public DateTime Btime { get; set; }
                public DateTime Duedate { get; set; }
                public string Position { get; set; }
    }
}