using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemens
{
    public class Patron
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string ContactInfo { get; set; }

        public List<Borrow> ActiveBorrows
        {
            get
            {
                var list = new List<Borrow>();
                foreach (Borrow b in BorrowingSystem.Borrows)
                {
                    if (b.PatronId == Id && !b.Returned)
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
