using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryEnterprise.Core.Data
{
    public interface IRepository<T> where T : class
    {
        bool Create(T item);

        bool Delete(T item);

        void Update(T item);

        T FindById(int id);

        T First(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetAll();

        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
    }
}
