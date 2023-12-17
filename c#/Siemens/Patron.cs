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

        public List<Borrow> Borrows { get; set; }
    }
}
