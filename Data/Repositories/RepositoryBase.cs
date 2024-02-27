using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskWebAPI;

namespace Data.Repositories
{
    public class RepositoryBase<T>: IRepositoryBase<T> where T : EntityBase
    {
        protected MtsbaseContext _context;
        protected DbSet<T> DbSet => _context.Set<T>();
        public IQueryable<T> Collection => _context.Set<T>();

        public RepositoryBase(MtsbaseContext context)
        {
            _context = context;
        }

        public void Add(T entity) => DbSet.Add(entity);

        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Attach(entity);
            }
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(object id)
        {
            var entity = GetById(id);
            Delete(entity);
        }

        public void DeleteRange(IEnumerable<T> list) => _context.Set<T>().RemoveRange(list);

        public void Edit(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
        }

        public T GetById(object id) => DbSet.Find(id);

        public bool Exists(object id) => DbSet.Any(_ => _.Id == (long)id);
        public void Save() => _context.SaveChanges();
    }
}
