namespace LibraryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            Book book1 = new Book("Тень ветра", "Карлос Руис Сафон", 2001);
            Book book2 = new Book("1984", "Джордж Оруэлл", 1949);
            library.AddBook(book1);
            library.AddBook(book2);

            Reader reader1 = new Reader(1, "Иван");
            Reader reader2 = new Reader(2, "Мария");
            library.AddReader(reader1);
            library.AddReader(reader2);

            reader1.BorrowBook(book1);
            reader2.BorrowBook(book2);

            reader1.DisplayBorrowedBooks();
            reader2.DisplayBorrowedBooks();


            reader1.ReturnBook(book1);

            reader1.DisplayBorrowedBooks();
        }
    }
}
