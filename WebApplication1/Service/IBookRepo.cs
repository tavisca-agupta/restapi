using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    //For all Types of get methods
    interface IBookRepo
    {
        IEnumerable<Book> GetAll();
        Book GetById(int id);
    }
}
