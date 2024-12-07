using Bibliotek;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bibliotek
{
    public class LibraryData
    {
        [JsonPropertyName("Books")]

        public List<Book> Books { get; set; }


        [JsonPropertyName("Authors")]

        public List<Author> Authors { get; set; }

        public LibraryData()
        {
            Books = new List<Book>();
            Authors = new List<Author>();
        }
    }
}
