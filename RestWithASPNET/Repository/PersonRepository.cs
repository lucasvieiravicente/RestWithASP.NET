using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Repository.Interfaces;
using RestWithASPNET.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private MySqlContext _context;

        public PersonRepository(MySqlContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {                            
            try
            {
                if (_context.Persons.Find(person.Id) == null)
                {
                    _context.Add(person);
                    _context.SaveChanges();
                }                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public void Delete(Guid personId)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(personId));
            try
            {
                if (result != null)
                {
                    _context.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Person> FindAll() => _context.Persons.ToList();        

        public Person FindById(Guid personId) => _context.Persons.Find(personId);                            

        public Person Update(Person person)
        {
            if (!Exist(person.Id)) return new Person() { FirstName = "Not", LastName = "Exist" };            
            
            try
            {
                var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        private bool Exist(Guid id) => _context.Persons.Find(id) != null ? true : false;        
    }
}
