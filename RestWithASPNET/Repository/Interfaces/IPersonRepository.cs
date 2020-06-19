using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Repository.Interfaces
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindById(Guid personId);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(Guid personId);
    }
}
