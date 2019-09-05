using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.DataBase
{
    public class BookServices
    {
        
        public IEnumerable<Book> GetAll()
        {
            return Data.bookList;
        }
        public Book GetById(int id)
        {
            return Data.bookList[id];
        }
        public void AddBook(JObject BookObject)
        {
            var booknumber = int.Parse(BookObject.GetValue("BookId").ToString());
            var bookPrice = int.Parse(BookObject.GetValue("Price").ToString());
            var bookName = BookObject.GetValue("BookName").ToString();
            var bookAuthor= BookObject.GetValue("BookAuthor").ToString();
            var bookCategory = BookObject.GetValue("Category").ToString();

            Data.bookList.Add(new Book { BookId = booknumber,
                                    BookName =bookName,
                                    Author=bookAuthor,
                                    Category=bookCategory,
                                    Price=bookPrice        });
        }

        public string UpdateBook(int id, JObject obj)
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
