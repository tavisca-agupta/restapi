using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebApplication1.Service;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bookController : ControllerBase
    {
        BookServices book = new BookServices();
        // GET: api/book
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return book.GetAll();
        }

        //GET: api/book/5
        [HttpGet("{id}", Name = "Get")]
        public Book Get(int id)
        {
            return book.GetById(id);
        }

        // POST: api/book
        [HttpPost]
        public string Post([FromBody] Book obj)
        {
            return book.AddBook(obj); 
        }

        // PUT: api/book/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Book obj)
        {
            return book.UpdateBook(id, obj);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
