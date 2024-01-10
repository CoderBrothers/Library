using System.Collections.Generic;
using System.Xml.Linq;

namespace LibraryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            Book book1 = new Book("Тень ветра", "Карлос Руис Сафон", 2001);
            Book book2 = new Book("1984", "Джордж Оруэлл", 1949);
            Book book3 = new Book("1984", "Джордж ddgddg", 1949);
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);

            Reader reader1 = new Reader("Иван");
            Reader reader2 = new Reader("Мария");
            library.AddReader(reader1);
            library.AddReader(reader2);

            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nLibrary Menu:");
                Console.WriteLine("1. Display All Books");
                Console.WriteLine("2. Display All Readers");
                Console.WriteLine("3. Display Borrowed Books by Reader (Enter Reader Id)");
                Console.WriteLine("4. Add Book");
                Console.WriteLine("5. Remove Book");
                Console.WriteLine("6. Add Reader");
                Console.WriteLine("7. Remove Reader");
                Console.WriteLine("8. Find Book by Title");
                Console.WriteLine("9. Find Book by Author");
                Console.WriteLine("10. Find Book by Year");
                Console.WriteLine("11. Find Reader by Name");
                Console.WriteLine("12. Borrow Book");
                Console.WriteLine("13. Return Book");
                Console.WriteLine("14. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        library.DisplayBooks();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "2":
                        library.DisplayReaders();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Write("Enter Reader ID: ");
                        if (int.TryParse(Console.ReadLine(), out int displayReaderId))
                        {
                            library.DisplayReaderBorrowedBooks(displayReaderId);
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Reader ID.");
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(title))
                        {
                            Console.WriteLine("Title cannot be null or empty. Please enter a valid title.");
                            break;
                        }
                        Console.Write("Enter Author: ");
                        string author = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(author))
                        {
                            Console.WriteLine("Author cannot be null or empty. Please enter a valid author.");
                            break;
                        }
                        Console.Write("Enter Year: ");
                        if (int.TryParse(Console.ReadLine(), out int year))
                        {
                            Book newBook = new Book(title, author, year);
                            library.AddBook(newBook);
                            Console.WriteLine("Book added successfully.");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();

                        }
                        else
                        {
                            Console.WriteLine("Invalid Year.");
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Write("Enter Title of the Book to Remove: ");
                        string bookTitleToRemove = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(bookTitleToRemove))
                        {
                            Console.WriteLine("Invalid input. Book title cannot be empty or whitespace.");
                            break;
                        }

                        IEnumerable<Book> booksToRemove = library.FindBooksByTitle(bookTitleToRemove);

                        if (booksToRemove.Any())
                        {
                            Book bookToRemove = booksToRemove.First();

                            if (bookToRemove != null)
                            {
                                library.RemoveBook(bookToRemove.Id);
                                Console.WriteLine($"Book {bookToRemove.Title} with ID {bookToRemove.Id} removed from the library.");
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Error: Book object is null.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Book with title {bookTitleToRemove} not found.");
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "6":
                        Console.Write("Enter Reader's Name: ");
                        string readerName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(readerName))
                        {
                            Console.WriteLine("Reader's Name cannot be null or empty. Please enter a valid name.");
                            break;
                        }
                        Reader newReader = new Reader(readerName);
                        library.AddReader(newReader);
                        Console.WriteLine($"Reader {readerName} added successfully.");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "7":
                        Console.Clear();
                        Console.Write("Enter Reader ID to Remove: ");
                        if (int.TryParse(Console.ReadLine(), out int readerIdToRemove))
                        {
                            Reader readerToRemove = library.FindReaderById(readerIdToRemove);

                            if (readerToRemove != null)
                            {
                                library.RemoveReader(readerToRemove.Id);
                                Console.WriteLine($"Reader with ID {readerIdToRemove} removed from the library.");
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine($"Reader with ID {readerIdToRemove} not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Reader ID.");
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "8":
                        Console.Write("Enter Title to Find: ");
                        string titleToFind = Console.ReadLine();
                        var foundBooksByTitle = library.FindBooksByTitle(titleToFind);
                        if (foundBooksByTitle.Any())
                        {
                            Console.WriteLine("Books found:");
                            foreach (var book in foundBooksByTitle)
                            {
                                Console.WriteLine(book);
                            }
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine($"No books found with title: {titleToFind}");
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "9":
                        Console.Write("Enter Author to Find: ");
                        string authorToFind = Console.ReadLine();
                        var foundBooksByAuthor = library.FindBooksByAuthor(authorToFind);
                        if (foundBooksByAuthor.Any())
                        {
                            Console.WriteLine("Books found:");
                            foreach (var book in foundBooksByAuthor)
                            {
                                Console.WriteLine(book);
                            }
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine($"No books found by author: {authorToFind}");
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "10":
                        Console.Write("Enter Year to Find: ");
                        if (int.TryParse(Console.ReadLine(), out int yearToFind))
                        {
                            var foundBooksByYear = library.FindBooksByYear(yearToFind);
                            if (foundBooksByYear.Any())
                            {
                                Console.WriteLine("Books found:");
                                foreach (var book in foundBooksByYear)
                                {
                                    Console.WriteLine(book);
                                }
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine($"No books found from the year: {yearToFind}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid year.");
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "11":
                        Console.Write("Enter Reader Name to Find: ");
                        string readerNameToFind = Console.ReadLine();
                        var foundReadersByName = library.FindReadersByName(readerNameToFind);
                        if (foundReadersByName.Any())
                        {
                            Console.WriteLine("Readers found:");
                            foreach (var reader in foundReadersByName)
                            {
                                Console.WriteLine(reader);
                            }
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine($"No readers found with name: {readerNameToFind}");
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "12":
                        Console.Write("Enter Reader ID to Borrow Book: ");
                        if (int.TryParse(Console.ReadLine(), out int borrowerID))
                        {
                            Reader borrower = library.FindReaderById(borrowerID);
                            if (borrower != null)
                            {
                                Console.Write("Enter Title of the Book to Borrow: ");
                                string bookTitleToBorrow = Console.ReadLine();
                                IEnumerable<Book> booksToBorrow = library.FindBooksByTitle(bookTitleToBorrow);
                                if (booksToBorrow.Any())
                                {
                                    Book bookToBorrow = booksToBorrow.First();
                                    borrower.BorrowBook(bookToBorrow);
                                }
                                else
                                {
                                    Console.WriteLine($"Book with title {bookTitleToBorrow} not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Reader with ID {borrowerID} not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID format.");
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "13":
                        Console.Write("Enter Reader ID to Return Book: ");
                        if (int.TryParse(Console.ReadLine(), out int returnerID))
                        {
                            Reader returner = (Reader)library.FindReaderById(returnerID);
                            if (returner != null)
                            {
                                Console.Write("Enter Title of the Book to Return: ");
                                string bookTitleToReturn = Console.ReadLine();
                                IEnumerable<Book> booksToReturn = returner.GetBorrowedBooks.Where(book => book.Title.Equals(bookTitleToReturn, StringComparison.OrdinalIgnoreCase));
                                if (booksToReturn.Any())
                                {
                                    Book bookToReturn = booksToReturn.First();
                                    returner.ReturnBook(bookToReturn);
                                }
                                else
                                {
                                    Console.WriteLine($"Book with title {bookTitleToReturn} not found in the borrowed books of Reader with ID {returnerID}.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Reader with ID {returnerID} not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID format.");
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "14":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
