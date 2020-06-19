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
        private IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void Delete(Guid personId)
        {
            _personRepository.Delete(personId);
        }

        public Person Create(Person person) => _personRepository.Create(person);

        public Person Update(Person person) => _personRepository.Update(person);

        public List<Person> FindAll() => _personRepository.FindAll();

        public Person FindById(Guid personId) => _personRepository.FindById(personId);                        
    }
}
