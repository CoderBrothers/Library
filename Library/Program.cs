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
                        Console.Write("Enter ID of the Book to Remove: ");
                        if (!int.TryParse(Console.ReadLine(), out int bookIdToRemove))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid numeric ID.");
                            break;
                        }
                        Book bookToRemoveById = library.FindBookById(bookIdToRemove);
                        if (bookToRemoveById != null)
                        {
                            if(bookToRemoveById.Status == BookStatus.Available)
                            {
                                library.RemoveBook(bookToRemoveById.Id);
                                Console.WriteLine($"Book {bookToRemoveById.Title} with ID {bookToRemoveById.Id} removed from the library.");
                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();
                            }
                            else
                                Console.WriteLine($"Book with ID {bookIdToRemove} is already reserved");
                        }
                        else
                        {
                            Console.WriteLine($"Book with ID {bookIdToRemove} not found.");
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
                        if (int.TryParse(Console.ReadLine(), out int yearToFind) && yearToFind > 0)
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
                                Console.Write("Enter ID of the Book to Borrow: ");
                                if (int.TryParse(Console.ReadLine(), out int bookIdToBorrow))
                                {
                                    Book bookToBorrow = library.FindBookById(bookIdToBorrow);
                                    if (bookToBorrow != null)
                                    {
                                        borrower.BorrowBook(bookToBorrow);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Book with ID {bookIdToBorrow} not found.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Book ID format.");
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
                            Reader returner = library.FindReaderById(returnerID);
                            if (returner != null)
                            {
                                Console.Write("Enter ID of the Book to Return: ");
                                if (int.TryParse(Console.ReadLine(), out int bookIdToReturn))
                                {
                                    Book bookToReturn = library.FindBookById(bookIdToReturn);
                                    if (bookToReturn != null)
                                    {
                                        returner.ReturnBook(bookToReturn);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Book with ID {bookIdToReturn} not found.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Book ID format.");
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
