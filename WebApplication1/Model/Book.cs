using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class Book
    {
        //Id, Name, Category, Price, Author
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Category { set; get; }
        public int Price { set; get; }
        public string Author { get; set; }
    }
}
