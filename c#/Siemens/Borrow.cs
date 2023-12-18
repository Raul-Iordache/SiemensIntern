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
        public string BookIsbn { get; set; } = string.Empty;
        public int PatronId { get; set; }
        public DateTime BorrowDate { get; set; }
        public int MaxDays { get; set; }
        public int FineRate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public bool Returned
        {
            get
            {
                return this.ReturnDate != null;
            }

        }

        public int Fine
        {
            get
            {
                var endDate = ReturnDate ?? DateTime.Today;
                TimeSpan diff = endDate.Subtract(BorrowDate);
                var fineDays = diff.Days - MaxDays;
                return fineDays > 0 ? fineDays * FineRate : 0;
            }
        }

    }
}
