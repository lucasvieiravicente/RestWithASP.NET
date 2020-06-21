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
    public class PersonService : IPersonService
    {
        private IRepository<Person> _repository;

        public PersonService(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public void Delete(Guid personId)
        {
            _repository.Delete(personId);
        }

        public Person Create(Person person) => _repository.Create(person);

        public Person Update(Person person) => _repository.Update(person);

        public List<Person> FindAll() => _repository.FindAll();

        public Person FindById(Guid personId) => _repository.FindById(personId);                        
    }
}
