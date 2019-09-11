using Newtonsoft.Json.Linq;
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
        List<JObject> Errors = new List<JObject>();
        public JObject BookId(int id)
        {
            JObject msg=null;
            if (!(id >= 0))     // Regex(@"/^[+]?([0-9]+(?:[\.][0-9]*)?|\.[0-9]+)$/")   for +ve numbers and decimal
            {// msg = "\"BookId\":\"Needs to Be Positive number\"";
                msg = JObject.Parse(@"{'BookId':'Needs to Be Positive number'}");
            }
            return msg;
        }
        public JObject Author(string author)
        {
            JObject msg =null;
            Regex regex = new Regex(@"^[a-zA-Z ]+$");
            if(!regex.IsMatch(author))
            { //msg = "Author: Name Can Only Contain Letters";
                msg = JObject.Parse(@"{'Author':'Can Only Contains Alphabets'}");
            }
            return msg;

        }
        public JObject Price(int price)
        {
            JObject msg = null;
            if (!(price >= 0))
            {// msg = "Price: Needs to Be Positive number";
                msg = JObject.Parse(@"{'Price':'Needs to Be Positive number'}");
            }
            return msg;
        }
        public JObject Category(string category)
        {
            JObject msg = null;
            Regex regex = new Regex(@"^[a-zA-Z]+$");
            if (!regex.IsMatch(category))
            {// msg = "Category: Can Only Contain Letters";
                msg = JObject.Parse(@"{'Category':'Can Only Contains Alphabets Without Space'}");
            }
            return msg;
        }
        public JObject BookName(string name)
        {
            JObject msg = null;
            Regex regex = new Regex(@"^[a-zA-Z ]+$");
            if (!regex.IsMatch(name))
            {// msg = "BookName: Can Only Contain Letters";
                msg = JObject.Parse(@"{'BookId':'Needs to Be Positive number'}");
            }
            return msg;
        }
        public List<JObject> All(Book book)
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
