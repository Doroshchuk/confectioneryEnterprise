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

        bool Update(Func<T, bool> predicate, T item);

        T First(Func<T, bool> predicate);

        IEnumerable<T> GetAll();

        IEnumerable<T> Get(Func<T, bool> predicate);
    }
}
