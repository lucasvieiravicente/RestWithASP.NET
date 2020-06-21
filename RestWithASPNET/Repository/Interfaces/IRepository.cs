using RestWithASPNET.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Repository.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        T Create(T item);
        T FindById(Guid id);
        List<T> FindAll();
        T Update(T item);
        void Delete(Guid Id);
    }
}
