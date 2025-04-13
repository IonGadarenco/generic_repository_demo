using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_repository_pattern_demo
{
    internal class ListRepository<T> : IRepository<T> where T : Entity
    {
        private List<T> _items = new List<T>();

        public void Add(T entity) => _items.Add(entity);

        public void Delete(T entity) => _items.Remove(entity);

        public IEnumerable<T> GetAll() => _items;

        public T GetById(int id) => _items.FirstOrDefault(e => e.Id == id);

        public void Update(T entity)
        {
            var index = _items.FindIndex(e => e.Id == entity.Id);
            if (index >= 0)
            {
                _items[index] = entity;
            }
        }
    }

}
