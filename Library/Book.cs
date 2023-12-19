using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Book
    {
        private Reservation _reservation;
        public BookStatus Status => _reservation.Status;
        public string Title { get; }
        public string Author { get; }
        public int Year { get; }

        public Book(string title, string author, int year)
        {
            (Title, Author, Year) = (title, author, year);
            _reservation = new Reservation();
        }
        public void BorrowBook()
        {
            if(_reservation.Status == BookStatus.Available)
            {
                _reservation.Reserve();
                Console.WriteLine("Book borrowed");
            }
            else
            {
                Console.WriteLine("Can`t borrow book");
            }
        }
        public void ReturnBook()
        {
            if (_reservation.Status == BookStatus.Borrowed)
            {
                _reservation.CancelReservation();
                Console.WriteLine("Book returned");
            }
            else
            {
                Console.WriteLine("Can`t return book");
            }
        }
    }
}
