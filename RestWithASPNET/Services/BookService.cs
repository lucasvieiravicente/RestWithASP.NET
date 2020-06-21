using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Repository.Interfaces;
using RestWithASPNET.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Services
{
    public class BookService : IBookService
    {        
        private IRepository<Book> _repository;

        public BookService(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public void Delete(Guid bookId)
        {
            _repository.Delete(bookId);
        }

        public Book Create(Book book) => _repository.Create(book);

        public Book Update(Book book) => _repository.Update(book);

        public List<Book> FindAll() => _repository.FindAll();

        public Book FindById(Guid bookId) => _repository.FindById(bookId);                        
    }
}
