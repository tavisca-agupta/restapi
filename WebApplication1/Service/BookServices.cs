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
using static WebApplication1.Service.FluentValidation;
using FluentValidation.Results;

namespace WebApplication1.Service
{
    public class BookServices
    {
        Validate Validate = new Validate();   //For Regex validation
        BookValidator Validator = new BookValidator(); //for fluent validation

        public ActionResult GetAll()
        {
            int statusCode;
            string content="";
            if (Data.bookList.Count > 0)
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
            string content;
            JObject error;
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
                    error = JObject.Parse(@"{'Error':'Please Enter Valid Index to Get The Book'}");

                content = JsonConvert.SerializeObject(error);
                statusCode = 404;
            }
            return Response(content, statusCode);

        }
        public ActionResult AddBook(Book BookObject)
        {
            string content; int statusCode;
            List<JObject> Error = new List<JObject>();
            Error = Validate.All(BookObject);                      //Own Validation done here 
            if (Error.Count < 1)
            {
                content = JsonConvert.SerializeObject(JObject.Parse(@"{'Success':'Book Added'}"));
                Data.bookList.Add(BookObject);
                statusCode = 201;
            }
            else
            {
                content = JsonConvert.SerializeObject((Error), Formatting.Indented);
                statusCode = 400;
            }

            //ValidationResult results = Validator.Validate(BookObject);   //Fluent validation done here
            //if (!results.IsValid)
            //{
            //    foreach (var failure in results.Errors)
            //    {
            //        Error.Add(failure.PropertyName + " " + failure.ErrorMessage);
            //    }
            //    string allMessages = results.ToString();
            //    content = JsonConvert.SerializeObject(Error, Formatting.Indented);
            //   // content = JsonConvert.SerializeObject(allMessages, Formatting.Indented);
            //    statusCode = 400;
            //}
            //else
            //{
            //    content = JsonConvert.SerializeObject("Result:Book Added");
            //    Data.bookList.Add(BookObject);
            //    statusCode = 201;
            //}

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
                content = JsonConvert.SerializeObject(JObject.Parse(@"{'Success':'Book Added'}"));
                statusCode = 201;
                
            }
            else
            {
                content= JsonConvert.SerializeObject(JObject.Parse(@"{'Error':'Book is not Present For Updation'}"));
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
