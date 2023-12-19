namespace LibraryApp
{
    public class Library
    {
        private List<Book> _books;
        private List<Reader> _readers;

        public Library()
        {
            _books = new List<Book>();
            _readers = new List<Reader>();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
            Console.WriteLine($"Book {book.Title} added to the library.");
        }

        public void AddReader(Reader reader)
        {
            _readers.Add(reader);
            Console.WriteLine($"Reader {reader.Name} added to the library.");
        }
        public void RemoveBook(Book book)
        {
            if ( _books.Contains(book) )
            {
                _books.Remove(book);
                Console.WriteLine($"Book {book.Title} removed from the library.");
            }
            else
                Console.WriteLine($"Book {book.Title} isn`t present.");
        }
        public void RemoveReader(Reader reader)
        {
            if (_readers.Contains(reader))
            {
                _readers.Remove(reader);
                Console.WriteLine($"Reader {reader.Name} removed from the library.");
            }
            else Console.WriteLine($"Reader {reader.Name} isn`t present.");
        }
        public void DisplayBooks()
        {
            foreach (Book book in _books)
            {
                Console.WriteLine($"Title: {book.Title} Author: {book.Author} Year: {book.Year} Status: {book.Status}");
            }
        }
        public void DisplayReaders()
        {
            foreach (Reader reader in _readers)
            {
                Console.WriteLine($"Id: {reader.Id} Name: {reader.Name}");
            }
        }
        public void DisplayReaderBorrowedBooks(int id)
        {
            //Сделать проверку айдишника.
            if()
        }
    }
}