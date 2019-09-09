using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public class BookServices
    {
        Validate Validate = new Validate();   
        public ActionResult GetAll()
        {
            int statusCode;
            string content="";
            if (Data.bookList.Count > 1)
            {
                content = JsonConvert.SerializeObject(Data.bookList);
                statusCode = 200;
            }
            else
                statusCode = 204;

            return Response(content, statusCode);
        }

        public ActionResult GetById(int id)
        {
            string content,error;
            int statusCode;
            try
            {
                content = JsonConvert.SerializeObject(Data.bookList[id]);
                statusCode = 200;

            }
            catch(Exception)
            {
                if (id < 0)
                    error = Validate.BookId(id);
                else
                    error = "Please Enter Valid Index to Get The Book";

                content = JsonConvert.SerializeObject(error);
                statusCode = 404;
            }
            return Response(content, statusCode);

        }
        public ActionResult AddBook(Book BookObject)
        {
            string content; int statusCode;
            List<string> Errors = new List<string>();
            Errors=Validate.All(BookObject);                      //Validation done here
            if (Errors.Count < 1)
            {
                content = JsonConvert.SerializeObject("Book Added");
                Data.bookList.Add(BookObject);
                statusCode = 201;
            }
            else
            {
                content = JsonConvert.SerializeObject(Errors,Formatting.Indented);
                statusCode = 400;
            }
            return Response(content,statusCode);
        }

        public ActionResult UpdateBook(int id, Book bookObject)
        {
            string content;int statusCode;
            Book BookToRemove=null;
            if(Validate.All(bookObject).Count<1)
                BookToRemove = Data.bookList.Find(x => x.BookId == id);
            
            if(BookToRemove!=null)
            {
                Data.bookList.Remove(BookToRemove);
                Data.bookList.Add(bookObject);
                content = JsonConvert.SerializeObject("Book Updated");
                statusCode = 201;
                
            }
            else
            {
                content= JsonConvert.SerializeObject("Book is not Present For Updation");
                statusCode = 404;
            }
            return Response(content, statusCode);
        }
        public string deleteBook()
        {
            return "We Have Deleted your Book";
        }
        public ActionResult Response(string content, int statusCode)
        {
            var response = new ContentResult()
            {
                Content = content,
                ContentType = "application/json",
                StatusCode = statusCode
            };
            return response;
        }

    }
}
