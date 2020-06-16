using RestWithASPNET.Model;
using RestWithASPNET.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Services
{
    public class PersonService : IPersonService
    {
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(Guid personId)
        {            
        }

        public List<Person> FindAll()
        {
            List<Person> personList = new List<Person>();

            for(int i = 0; i < 8; i++)
            {
                personList.Add(MockPerson(i));
            }

            return personList;
        }

        public Person FindById(Guid personId)
        {
            return new Person()
            {
                Id = Guid.Parse("c2abd7ad-a7e4-4a73-af63-39472f1e8fdf"),
                FirstName = "Lucas",
                LastName = "Vieira Vicente",
                Address = "Mauá - São Paulo, Brasil",
                Gender = Gender.Masculine
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = $"Person Name {i}",
                LastName = $"Person LastName{i}",
                Address = "Mauá - São Paulo, Brasil",
                Gender = i % 2 == 0 ? Gender.Masculine : Gender.Female
            };
        }
    }
}
