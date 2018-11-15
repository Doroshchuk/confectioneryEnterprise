using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConfectioneryEnterprise.Core.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly string _name;
        private readonly string _path;
        private List<T> _items = new List<T>();

        public Repository(string name)
        {
            _name = name;
            _path = AppDomain.CurrentDomain.BaseDirectory + "\\Data\\" + name + ".json";
            string json = File.ReadAllText(_path);

            _items = JsonConvert.DeserializeObject<List<T>>(json);
        }

        public bool Create(T item)
        {
            try
            {
                _items.Add(item);
                return Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Delete(T item)
        {
            throw new NotImplementedException();
        }

        public T FindById(int id)
        {
            throw new NotImplementedException();
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        private bool Save()
        {
            try
            {
                string jsonItems = JsonConvert.SerializeObject(_items);
                File.WriteAllText(_path, JArray.Parse(jsonItems).ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
