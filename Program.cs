using Bibliotek;

namespace LibraryManagementAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            string filePath = "LibraryData.json";
            library.LoadDataFromJson(filePath);

            int choice;
            do
            {
                Console.WriteLine("Välj ett av följande alternativ:");
                Console.WriteLine("1. Lägg till bok");
                Console.WriteLine("2. Lägg till författare");
                Console.WriteLine("3. Uppdatera bokdetaljer");
                Console.WriteLine("4. Uppdatera författardetaljer");
                Console.WriteLine("5. Ta bort bok");
                Console.WriteLine("6. Ta bort författare");
                Console.WriteLine("7. Visa alla böcker och författare");
                Console.WriteLine("8. Sök efter bok efter genre");
                Console.WriteLine("9. Spara och avsluta");
                Console.Write("Ange ditt val: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Ogiltig inmatning. Vänligen ange ett nummer.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddBook(library);
                        break;
                    case 2:
                        AddAuthor(library);
                        break;
                    case 3:
                        UpdateBookDetails(library);
                        break;
                    case 4:
                        UpdateAuthorDetails(library);
                        break;
                    case 5:
                        RemoveBook(library);
                        break;
                    case 6:
                        RemoveAuthor(library);
                        break;
                    case 7:
                        ShowAllBooksAndAuthors(library);
                        break;
                    case 8:
                        SearchBooksByGenre(library);
                        break;
                    case 9:
                        library.SaveDataToJson(filePath);
                        Console.WriteLine("Data sparades framgångsrikt.");
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, vänligen försök igen.");
                        break;
                }

                Console.WriteLine();
            } while (choice != 9);
        }

        static void AddBook(Library library)
        {
            Console.Write("Ange boktitel: ");
            string title = Console.ReadLine();

            Console.Write("Ange författarens namn: ");
            string author = Console.ReadLine();

            Console.Write("Ange genre: ");
            string genre = Console.ReadLine();

            Console.Write("Ange publiceringsår: ");
            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                Console.WriteLine("Ogiltigt år.");
                return;
            }

            Console.Write("Ange ISBN: ");
            if (!int.TryParse(Console.ReadLine(), out int isbn))
            {
                Console.WriteLine("Ogiltigt ISBN.");
                return;
            }

            Book newBook = new Book(title, author, genre, year, isbn);
            library.AddBook(newBook);
            Console.WriteLine("Bok tillagd framgångsrikt.");
        }

        static void AddAuthor(Library library)
        {
            Console.Write("Ange författar-ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ogiltigt ID.");
                return;
            }
            Console.Write("Ange författarens namn: ");
            string name = Console.ReadLine();

            Console.Write("Ange författarens land: ");
            string country = Console.ReadLine();

            Author newAuthor = new Author(id, name, country);
            library.AddAuthor(newAuthor);
            Console.WriteLine("Författare tillagd framgångsrikt.");
        }

        static void UpdateBookDetails(Library library)
        {
            Console.Write("Ange bok-ID för att uppdatera: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ogiltigt ID.");
                return;
            }

            Console.Write("Ange ny titel: ");
            string newTitle = Console.ReadLine();

            Console.Write("Ange ny författare: ");
            string newAuthor = Console.ReadLine();

            Console.Write("Ange ny genre: ");
            string newGenre = Console.ReadLine();

            Console.Write("Ange nytt publiceringsår: ");
            if (!int.TryParse(Console.ReadLine(), out int newYear))
            {
                Console.WriteLine("Ogiltigt år.");
                return;
            }

            Console.Write("Ange nytt ISBN: ");
            if (!int.TryParse(Console.ReadLine(), out int newIsbn))
            {
                Console.WriteLine("Ogiltigt ISBN.");
                return;
            }

            library.UpdateBook(id, newTitle, newAuthor, newGenre, newYear, newIsbn, new List<int>());
            Console.WriteLine("Bokdetaljer uppdaterade framgångsrikt.");
        }

        static void UpdateAuthorDetails(Library library)
        {
            Console.Write("Ange författar-ID för att uppdatera: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ogiltigt ID.");
                return;
            }

            Console.Write("Ange nytt namn för författaren: ");
            string newName = Console.ReadLine();

            Console.Write("Ange nytt land: ");
            string newCountry = Console.ReadLine();

            library.UpdateAuthor(id, newName, newCountry);
            Console.WriteLine("Författardetaljer uppdaterade framgångsrikt.");
        }

        static void RemoveBook(Library library)
        {
            Console.Write("Ange bok-ID för att ta bort: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ogiltigt ID.");
                return;
            }

            library.RemoveBook(id);
            Console.WriteLine("Bok borttagen framgångsrikt.");
        }

        static void RemoveAuthor(Library library)
        {
            Console.Write("Ange författar-ID för att ta bort: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ogiltigt ID.");
                return;
            }

            library.RemoveAuthor(id);
            Console.WriteLine("Författare borttagen framgångsrikt.");
        }

        static void ShowAllBooksAndAuthors(Library library)
        {
            Console.WriteLine("Böcker:");
            library.ListAllBooks();
            Console.WriteLine("\nFörfattare:");
            library.ListAllAuthors();
        }

        static void SearchBooksByGenre(Library library)
        {
            Console.Write("Ange genre att söka efter: ");
            string genre = Console.ReadLine();
            library.SearchBooksByGenre(genre);
        }
    }
}
