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
            if (book == null)
                return;
            _books?.Add(book);
            Console.WriteLine($"Book {book.Title} added to the library.");
        }
        public void AddReader(Reader reader)
        {
            if (reader == null) 
                return;
            _readers?.Add(reader);
            Console.WriteLine($"Reader {reader.Name} added to the library.");
        }
        public void RemoveBook(int bookId)
        {
            Book bookToRemove = _books.FirstOrDefault(book => book.Id == bookId);

            if (bookToRemove != null)
            {
                _books?.Remove(bookToRemove);
                Console.WriteLine($"Book {bookToRemove.Title} removed from the library.");
            }
            else
            {
                Console.WriteLine($"Book with ID {bookId} isn't present.");
            }
        }
        public void RemoveReader(int readerId)
        {
            Reader readerToRemove = _readers.FirstOrDefault(reader => reader.Id == readerId);

            if (readerToRemove != null)
            {
                _readers?.Remove(readerToRemove);
                Console.WriteLine($"Reader {readerToRemove.Name} with ID {readerToRemove.Id} removed from the library.");
            }
            else
            {
                Console.WriteLine($"Reader with ID {readerId} isn't present in the library.");
            }
        }
        public void DisplayBooks()
        {
            foreach (Book book in _books)
            {
                Console.WriteLine(book);
            }
        }
        public void DisplayReaders()
        {
            foreach (Reader reader in _readers)
            {
                Console.WriteLine(reader);
            }
        }
        public void DisplayReaderBorrowedBooks(int id)
        {
            Reader? reader = _readers?.Find(r => r.Id == id);
            if (reader != null)
            {
                reader.DisplayBorrowedBooks();
            }
            else
            {
                Console.WriteLine($"Reader with Id {id} not found.");
            }
        }
        public IEnumerable<Book> FindBooksByTitle(string title) => _books.Where(book => book.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        public IEnumerable<Book> FindBooksByAuthor(string author) => _books.Where(book => book.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
        public IEnumerable<Book> FindBooksByYear(int year) => _books.Where(book => book.Year == year);
        public Book FindBookById(int id) => _books.FirstOrDefault(book => book.Id == id);
        public IEnumerable<Reader> FindReadersByName(string name) => _readers.Where(reader => reader.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        public Reader FindReaderById(int id) => _readers.FirstOrDefault(reader => reader.Id == id);
    }
}