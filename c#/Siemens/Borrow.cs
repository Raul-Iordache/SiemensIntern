using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemens
{
    public class Borrow
    {
        public int BorrowId { get; set; }
        public string BookIsbn { get; set; }
        public int PatronId { get; set; }
        public DateTime BorrowDate { get; set; }
        public bool Returned { get; set; }

    }
}
