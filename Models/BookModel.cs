using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMVC5.Models
{
    public class BookModel
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailableForRental { get; set; }
    }
}