using System;
using Xunit;
using WebApplication1.DataBase;
using WebApplication1.Model;
using Newtonsoft.Json;

namespace WebApplication1.Test
{
    public class UnitTest1
    {
        BookServices BS = new BookServices();
        [Fact]
        public void Test1()
        {
            Book b = new Book{BookId= 2,BookName= "Never Ending",Category= "Romance",Price= 500,Author= "Chetan Bhagat" };
            string JSONobject = JsonConvert.SerializeObject(b);
            BS.AddBook(JSONobject);
        }
    }
}
