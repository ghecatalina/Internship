using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndCollections
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private HashSet<T> table = new HashSet<T>();

        public void Delete(int id)
        {
            table.Remove(GetById(id));
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(int id)
        {
            return table.ElementAt(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            //throw new NotImplementedException();
        }
    }
}
