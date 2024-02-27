using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> Collection { get; }
        void Add(T entity);
        void Delete(T entity);
        void Delete(object id);
        void DeleteRange(IEnumerable<T> list);
        void Edit(T entity);
        T GetById(object id);
        bool Exists(object id);
        void Save();
    }
}
