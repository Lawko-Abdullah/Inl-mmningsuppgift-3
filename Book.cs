using System.Text.Json.Serialization;

namespace Bibliotek
{
    
    public class Book
    {

        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Author")]
        public string Author { get; set; }

        [JsonPropertyName("PublishYear")]
        public int PublishYear { get; set; }

        [JsonPropertyName("Genre")]
        public string Genre { get; set; }

        [JsonPropertyName("Isbn")]
        public int Isbn { get; set; }

        [JsonPropertyName("Review")]
        public List<int> Review { get; set; } 

    
        public Book(string title, string author, string genre, int publishYear, int isbn, List<int> review = null)
        {
            Title = title;
            Author = author;
            Genre = genre;
            PublishYear = publishYear;
            Isbn = isbn;
            Review = review ?? new List<int>(); 
        }

       
        public double CalculateAverageRating()
        {
            if (Review.Count == 0) return 0;
            return Review.Average();
        }
    }
}
