﻿namespace LibraryApp
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
        public void RemoveBook(Book book)
        {
            if (_books.Contains(book))
            {
                _books?.Remove(book);
                Console.WriteLine($"Book {book.Title} removed from the library.");
            }
            else
                Console.WriteLine($"Book {book.Title} isn`t present.");
        }
        public void RemoveReader(Reader reader)
        {
            if (_readers.Contains(reader))
            {
                _readers?.Remove(reader);
                Console.WriteLine($"Reader {reader.Name} removed from the library.");
            }
            else Console.WriteLine($"Reader {reader.Name} isn`t present.");
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
        //public IEnumerable<Book> FindBooksByTitle(string title)
        //{
        //    //Сделать реализацию.
        //} 
        //public IEnumerable<Book> FindBooksByAuthor(string author)
        //{

        //}
        public IEnumerable<Book> FindBooksByYear(int year)
        {
            //Переписать через Linq в одну строку.
            foreach(Book book in _books)
            {
                if (book.Year == year)
                {
                    yield return book;
                }
            }
        }
        //public IEnumerable<Reader> FindReadersByName(string name) 
        //{

        //}
    }
}