using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public class Validate
    {
        List<string> Errors = new List<string>();
        public string BookId(int id)
        {
            string msg=null;
            if (!(id >= 0))
            { msg = "BookId: Needs to Be Positive number"; }
            return msg;
        }
        public string Author(string author)
        {
            string msg =null;
            Regex regex = new Regex(@"^[a-zA-Z]+$");
            if(!regex.IsMatch(author))
            { msg = "Author: Name Can Only Contain Letters"; }
            return msg;

        }
        public string Price(int price)
        {
            string msg = null;
            if (!(price >= 0))
            { msg = "Price: Needs to Be Positive number"; }
            return msg;
        }
        public string Category(string category)
        {
            string msg = null;
            Regex regex = new Regex(@"^[a-zA-Z]+$");
            if (!regex.IsMatch(category))
            { msg = "Category: Can Only Contain Letters"; }
            return msg;
        }
        public string BookName(string name)
        {
            string msg = null;
            Regex regex = new Regex(@"^[a-zA-Z]+$");
            if (!regex.IsMatch(name))
            { msg = "BookName: Can Only Contain Letters"; }
            return msg;
        }
        public List<string> All(Book book)
        {
            if(BookName(book.BookName)!=null)
                Errors.Add(BookName(book.BookName));

            if(BookId(book.BookId)!=null)
                Errors.Add(BookId(book.BookId));

            if(Author(book.Author)!=null)
                Errors.Add(Author(book.Author));

            if(Category(book.Category)!= null)
                Errors.Add(Category(book.Category));

            if(Price(book.Price)!=null)
                Errors.Add(Price(book.Price));

            return Errors;

        }
    }

}
