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


        public bool Borrow()
        {
            return true;
        }
        public void Return()
        {

        }
    }

}
