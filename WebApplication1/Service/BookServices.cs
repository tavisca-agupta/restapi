using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public class BookServices
    {
        Validate Validate = new Validate();   
        public IEnumerable<Book> GetAll()
        {
            return Data.bookList;
        }
        public Book GetById(int id)
        {
            return Data.bookList[id];
        }
        public string AddBook(Book BookObject)
        {
            string response = "";
            List<string> Errors = new List<string>();
            Errors=Validate.All(BookObject);
            if (Errors.Count < 1)
            {
                //JObject res = JObject.Parse(Errors);
                response = JsonConvert.SerializeObject("Book Added", Formatting.Indented);
            }

            else
                response = JsonConvert.SerializeObject(Errors, Formatting.Indented);
                        
            Data.bookList.Add(BookObject);
            return response;
        }

        public string UpdateBook(int id, Book obj)
        {
            int flag = 0;
            Book BookToRemove=null;
            string msg = "Updation Done";
            foreach (Book book in Data.bookList)
                if (book.BookId == id)
                {
                    flag++;
                    BookToRemove = book;
                }
            Data.bookList.Remove(BookToRemove);
            if (flag > 0)
                 AddBook(obj); 
            else
                 msg = "Book is not Present For Updation"; 

            return msg;
        }
        public string deleteBook()
        {
            return "We Have Deleted your Book";
        }
       
    }
}
