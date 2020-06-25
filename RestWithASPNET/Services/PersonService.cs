using RestWithASPNET.Data.Converters;
using RestWithASPNET.Data.VO;
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
        private readonly PersonConverter _converter;

        public PersonService(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public void Delete(Guid personId)
        {
            _repository.Delete(personId);
        }

        public PersonVO Create(PersonVO person)
        {   
            var result = _repository.Create(_converter.Parse(person));
            return _converter.Parse(result);
        }

        public PersonVO Update(PersonVO person)
        {
            var result = _repository.Update(_converter.Parse(person));
            return _converter.Parse(result);
        }

        public List<PersonVO> FindAll() => _converter.ParseList(_repository.FindAll());

        public PersonVO FindById(Guid personId) => _converter.Parse(_repository.FindById(personId));                        
    }
}
