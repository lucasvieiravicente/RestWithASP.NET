using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Model.Base;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySqlContext _context;
        private DbSet<T> _dataSet;

        public BaseRepository(MySqlContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                var content = FindById(item.Id);
                if (content == null)
                {
                    _dataSet.Add(item);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }

        public void Delete(Guid id)
        {
            try
            {
                var item = FindById(id);
                if (item != null)
                {
                    _dataSet.Remove(item);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }                  

        public T Update(T item)
        {
            var content = FindById(item.Id);
            try
            {
                if (content != null)
                {
                    _context.Entry(content).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }

        public List<T> FindAll() => _dataSet.ToList();

        public T FindById(Guid id) => _dataSet.SingleOrDefault(s => s.Id == id);
    }
}
