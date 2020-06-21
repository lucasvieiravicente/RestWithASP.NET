using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Services.Interfaces
{
    public interface IBookService
    {
        Book Create(Book book);
        Book FindById(Guid bookId);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(Guid bookId);
    }
}
