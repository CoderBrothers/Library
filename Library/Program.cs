﻿using System.Xml.Linq;

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

            Reader reader1 = new Reader(1, "Иван");
            Reader reader2 = new Reader(2, "Мария");
            library.AddReader(reader1);
            library.AddReader(reader2);

            Console.Clear();
            while (true)
            {
                //Добавить использование linq методов
                //Добавить возможность выдачи и приёма книг
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

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        library.DisplayBooks();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        library.DisplayReaders();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        Console.Write("Enter Reader Id: ");
                        if (int.TryParse(Console.ReadLine(), out int readerId))
                        if (reader != null)
                        {
                            Console.WriteLine($"Borrowed books by Reader with ID {readerId}:");
                            foreach (Book book in reader1.GetBorrowedBooks)
                            {
                                    Console.WriteLine($"Book ID: {book.ID}, Title: {book.Title}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Reader with ID {readerId} not found.");
                        }
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
                        }
                        else
                        {
                            Console.WriteLine("Invalid Year.");
                        }
                        break;
                    case "5":
                        Console.Write("Enter Title of the Book to Remove: ");
                        string bookTitleToRemove = Console.ReadLine();
                        IEnumerable<Book> booksToRemove = library.FindBooksByTitle(bookTitleToRemove);
                        if (booksToRemove.Any())
                        {
                            Book bookToRemove = booksToRemove.First();
                            library.RemoveBook(bookToRemove);
                        }
                        else
                        {
                            Console.WriteLine($"Book with title {bookTitleToRemove} not found.");
                        }
                        break;
                    case "6":
                        Console.Write("Enter Reader's Name: ");
                        string readerName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(readerName))
                        {
                            Console.WriteLine("Reader's Name cannot be null or empty. Please enter a valid name.");
                            break;
                        }
                        Reader newReader = new Reader(0, readerName);
                        library.AddReader(newReader);
                        Console.WriteLine($"Reader {readerName} added successfully.");
                        break;
                    case "7":
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
                        }
                        else
                        {
                            Console.WriteLine($"No books found with title: {titleToFind}");
                        }
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
                        }
                        else
                        {
                            Console.WriteLine($"No books found by author: {authorToFind}");
                        }
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
                        }
                        else
                        {
                            Console.WriteLine($"No readers found with name: {readerNameToFind}");
                        }
                        break;
                    //Реализовать кейсы 12 и 13 и 3 через ID
                    case "12":
                        Console.Write("Enter Reader ID to Borrow Book: ");
                        if (int.TryParse(Console.ReadLine(), out int borrowerID))
                        {
                            Reader borrower = library.FindReaderByID(borrowerID);
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
                        break;
                    case "13":
                        Console.Write("Enter Reader ID to Return Book: ");
                        if (int.TryParse(Console.ReadLine(), out int returnerID))
                        {
                            Reader returner = library.FindReaderByID(returnerID);
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
                        break;
                    case "14":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
    }
}
