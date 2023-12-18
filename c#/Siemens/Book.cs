using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemens
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public int Quantity { get; set; }
        public List<Borrow> ActiveBorrows {
            get
            {
                var list = new List<Borrow>();
                foreach (Borrow b in BorrowingSystem.Borrows)
                {
                    if (b.BookIsbn == Isbn && !b.Returned)
                    {
                        list.Add(b);
                    }
                }
                return list;
            }
            
        }

        public int CurrentBorrowsCount
        {
            get
            {
                return this.ActiveBorrows.Count;
            }

        }


    }

}
