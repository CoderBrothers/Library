﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Book
    {
        //Прикрутить ID
        private Reservation _reservation;
        public BookStatus Status => _reservation.Status;
        public int ID { get; set; }
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

        public override string ToString()
        {
            return $"Title: {Title} Author: {Author} Year: {Year} Status: {Status}";
        }
    }
}
