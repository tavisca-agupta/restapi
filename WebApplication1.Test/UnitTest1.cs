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
    public class UnitTest1
    {
        BookServices BS = new BookServices();
        [Fact]
        public void AddingBookByPostWithoutNull()
        {
            Book b = new Book{BookId= 2,BookName= "NeverEnding",Category= "Romance",Price= 500,Author= "ChetanBhagat" };
            var expected= JsonConvert.SerializeObject("Book Added", Formatting.Indented);
            var actual=BS.AddBook(b);
            Assert.Equal(expected,actual);

        }
        [Fact]
        public void AddingBookByPostWithNegativeId()
        {
            Book b = new Book { BookId = -8, BookName = "NeverEnding", Category = "Romance", Price = 500, Author = "ChetanBhagat" };
            List<string> li = new List<string>() { "BookId: Needs to Be Positive number" };
            var expected = JsonConvert.SerializeObject(li, Formatting.Indented);
            var actual = BS.AddBook(b);
            Assert.Equal(expected, actual);

        }
    }
}
