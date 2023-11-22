using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c;
        DbSet<T> _object;

        public GenericRepository(Context context)
        {
            c = context;
            _object = c.Set<T>();
        }

        public void Delete(T p)
        {
            c.Remove(p);

        }

        public T GetByID(int id)
        {
            return _object.Find(id);
        }

        public void Insert(T p)
        {
            c.Add(p);
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            c.Update(p);
        }
    }
}
