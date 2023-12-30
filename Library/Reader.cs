using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryApp
{
    public class Reader
    {
        private static int _counter = 0;

        public int Id { get; }
        public string Name { get; }
        private List<Book> _borrowedBooks;

        public Reader(string name)
        {
            _counter++;
            Id = _counter;
            Name = name;
            _borrowedBooks = new List<Book>();
        }
        public List<Book> GetBorrowedBooks => _borrowedBooks;
        public void BorrowBook(Book book)
        {
            if (book.Status == BookStatus.Available)
            {
                book.BorrowBook();
                _borrowedBooks.Add(book);
                Console.WriteLine("Book borrowed");
            }
            else
            {
                Console.WriteLine("Can't borrow book");
            }
        }

        public void ReturnBook(Book book)
        {
            if (_borrowedBooks.Contains(book))
            {
                book.ReturnBook();
                _borrowedBooks.Remove(book);
                Console.WriteLine("Book returned");
            }
            else
            {
                Console.WriteLine("Can't return book");
            }
        }

        public void DisplayBorrowedBooks()
        {
            Console.WriteLine($"List of books taken by the reader {Name}:");
            foreach (var book in _borrowedBooks)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();
        }

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name}";
        }
    }
}
