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
                Console.WriteLine("8. Exit");

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
                        Console.Write("Enter Reader Id: ");
                        if (int.TryParse(Console.ReadLine(), out int readerId))
                        {
                            library.DisplayReaderBorrowedBooks(readerId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Reader Id.");
                        }
                        break;
                    case "4":
                        //Доделать проверку на is null or white space
                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter Author: ");
                        string author = Console.ReadLine();
                        Console.Write("Enter Year: ");
                        if (int.TryParse(Console.ReadLine(), out int year))
                        {
                            Book newBook = new Book(title, author, year);
                            library.AddBook(newBook);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Year.");
                        }
                        break;
                    case "5":
                        Console.Write("Enter Title of the Book to Remove: ");
                        string bookTitleToRemove = Console.ReadLine();
                        if (bookTRemove != null)
                        {
                            library.RemoveBook(bookToRemove);
                        }
                        else
                        {
                            Console.WriteLine($"Book with title {bookTitleToRemove} not found.");
                        }
                        break;
                    case "6":

                    case "7":
                        Console.Write("Enter Reader Id to Remove: ");

                        break;
                    case "8":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice. Please try again.");
                        break;
                }
            }
        }
    }
}
