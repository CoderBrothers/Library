using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Reservation
    {
        private BookStatus _status;
        public BookStatus Status => _status;
        public Reservation() 
        {
            _status = BookStatus.Available;
        }
        public void Reserve() 
        {
            if (_status == BookStatus.Available) 
            {
                _status = BookStatus.Reserved;
                Console.WriteLine("Book reserved");
            }
            else
            {
                Console.WriteLine("Book can`t be reserved");
            }
        }
        public void CancelReservation()
        {
            if ( _status == BookStatus.Reserved)
            {
                _status = BookStatus.Available;
                Console.WriteLine("Reservation canceled");
            }
            else
            {
                Console.WriteLine("Can`t cancel reservation");
            }
        }
    }
}
