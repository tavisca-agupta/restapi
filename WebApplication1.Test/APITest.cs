using System;
using Xunit;
using WebApplication1.Service;
using WebApplication1.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace WebApplication1.Test
{
    public class APITest
    {
        BookServices BS = new BookServices();
        [Fact]
        public void AddingBookByPost_WithoutNull()
        {
            Book b = new Book{BookId= 2,BookName= "NeverEnding",Category= "Romance",Price= 500,Author= "ChetanBhagat" };
            var expected= JsonConvert.SerializeObject("Book Added", Formatting.Indented);
            var actual=BS.AddBook(b);
            Assert.Equal(expected,actual);

        }
        [Fact]
        public void AddingBookByPostWith_NegativeId()
        {
            Book b = new Book { BookId = -8, BookName = "NeverEnding", Category = "Romance", Price = 500, Author = "ChetanBhagat" };
            List<string> li = new List<string>() { "BookId: Needs to Be Positive number" };
            var expected = JsonConvert.SerializeObject(li, Formatting.Indented);
            var actual = BS.AddBook(b);
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void AddingBookByPostWith_SpecialChars()
        {
            Book b = new Book { BookId = 8, BookName = "^&NeverEnding", Category = "Romance", Price = 500, Author = "ChetanBhagat" };
            List<string> li = new List<string>() { "BookName: Can Only Contain Letters" };
            var expected = JsonConvert.SerializeObject(li, Formatting.Indented);
            var actual = BS.AddBook(b);
            Assert.Equal(expected, actual);

        }
    }
}
