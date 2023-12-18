using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemens
{
    public static class BorrowingSystem
    {
        public const int MaxBooksPerClient = 10;
        public const int MaxDaysPerBook = 20;
        public const int FineRatePerDay = 30;

        private static int _lastBorrowId = 0;

        public static List<Book> Books { get; set; } = new List<Book>();
        public static List<Patron> Patrons { get; set; } = new List<Patron>();
        public static List<Borrow> Borrows { get; set; } = new List<Borrow>();

        public static bool Borrow(int patronId, string isbn)
        {
            var patron = GetPatronById(patronId);
            if (patron == null) 
                throw new Exception("This client is not registered in our system!");

            var book = GetBookByIsbn(isbn);
            if (book == null) throw new Exception("This book does not exist!");

            if (book.CurrentBorrowsCount > book.Quantity) throw new Exception("In this moment the book is out of stock!");

            if (patron.CurrentBorrowsCount > MaxBooksPerClient) throw new Exception("This client reach the maximum number of books");

            _lastBorrowId ++;
            var borrow = new Borrow()
            {
                BorrowId = _lastBorrowId,
                PatronId = patronId,
                BookIsbn = isbn,
                BorrowDate = DateTime.Now,
                MaxDays = MaxDaysPerBook,
                FineRate = FineRatePerDay
            };
            Borrows.Add(borrow);
            return true;

        }

        public static void ReturnBook(int borrowId)
        {
            var exist = false;
            foreach (Borrow borrow in Borrows)
            {
                if (borrow.BorrowId == borrowId)
                {
                    borrow.ReturnDate = DateTime.Now;
                    exist = true;
                    break;
                }
            }
            if (exist == false)
            {
                throw new Exception("This borrowId not exist!");
            }
        }


        private static Book? GetBookByIsbn(string isbn)
        {
            foreach (Book book in Books)
            {
                if (book.Isbn == isbn)
                {
                    return book;
                }
            }
            return null;
        }

        private static Patron? GetPatronById(int patronId)
        {
            foreach (Patron patron in Patrons)
            {
                if (patron.Id == patronId)
                {
                    return patron;
                }
            }
            return null;
        }

    }

    
}
