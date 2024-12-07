using System.Text.Json.Serialization;

namespace Bibliotek
{
    
    public class Author
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Country")]
        public string Country { get; set; }

        
        public Author(int id, string name, string country)
        {
            Id = id;
            Name = name;
            Country = country;
        }
    }
}
