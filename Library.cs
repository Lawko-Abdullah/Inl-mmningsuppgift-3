using Bibliotek;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Bibliotek
{
    public class Library
    {
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; }

        public Library()
        {
            Books = new List<Book>();
            Authors = new List<Author>();
        }

        public void LoadDataFromJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    var jsonData = File.ReadAllText(filePath);
                    var data = JsonSerializer.Deserialize<LibraryData>(jsonData);
                    Books = data?.Books ?? new List<Book>();
                    Authors = data?.Authors ?? new List<Author>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fel vid inläsning av data: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("JSON-fil hittades inte. Börjar med en tom biblioteksdatabas.");
            }
        }

        public void SaveDataToJson(string filePath)
        {
            var data = new LibraryData { Books = Books, Authors = Authors };
            var jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine("Data sparad framgångsrikt.");
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
            Console.WriteLine("Bok tillagd framgångsrikt.");
        }

        public void AddAuthor(Author author)
        {
            Authors.Add(author);
            Console.WriteLine("Författare tillagd framgångsrikt.");
        }

        public void UpdateBook(int id, string newTitle, string newAuthor, string newGenre, int newYear, int newIsbn, List<int> newReview)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                book.Title = newTitle;
                book.Author = newAuthor;
                book.Genre = newGenre;
                book.PublishYear = newYear;
                book.Isbn = newIsbn;
                book.Review = newReview;
                Console.WriteLine("Bokdetaljer uppdaterade framgångsrikt.");
            }
            else
            {
                Console.WriteLine("Boken hittades inte.");
            }
        }

        public void UpdateAuthor(int id, string newName, string newCountry)
        {
            var author = Authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                author.Name = newName;
                author.Country = newCountry;
                Console.WriteLine("Författardetaljer uppdaterade framgångsrikt.");
            }
            else
            {
                Console.WriteLine("Författaren hittades inte.");
            }
        }

        public void RemoveBook(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                Books.Remove(book);
                Console.WriteLine("Bok borttagen framgångsrikt.");
            }
            else
            {
                Console.WriteLine("Boken hittades inte.");
            }
        }

        public void RemoveAuthor(int id)
        {
            var author = Authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                Authors.Remove(author);
                Console.WriteLine("Författare borttagen framgångsrikt.");
            }
            else
            {
                Console.WriteLine("Författaren hittades inte.");
            }
        }

        public void ListAllBooks()
        {
            if (Books.Count == 0)
            {
                Console.WriteLine("Inga böcker tillgängliga.");
            }
            else
            {
                foreach (var book in Books)
                {
                    Console.WriteLine($"Titel: {book.Title}, Författare: {book.Author}, Genre: {book.Genre}, År: {book.PublishYear}, Betyg: {book.CalculateAverageRating():0.0}");
                }
            }
        }

        public void ListAllAuthors()
        {
            if (Authors.Count == 0)
            {
                Console.WriteLine("Inga författare tillgängliga.");
            }
            else
            {
                foreach (var author in Authors)
                {
                    Console.WriteLine($"Författare: {author.Name}, Land: {author.Country}");
                }
            }
        }

        public void SearchBooksByGenre(string genre)
        {
            var filteredBooks = Books.Where(b => b.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase)).ToList();
            if (filteredBooks.Any())
            {
                foreach (var book in filteredBooks)
                {
                    Console.WriteLine($"Titel: {book.Title}, Författare: {book.Author}, Genre: {book.Genre}");
                }
            }
            else
            {
                Console.WriteLine("Inga böcker hittades för den angivna genren.");
            }
        }
    }
}
