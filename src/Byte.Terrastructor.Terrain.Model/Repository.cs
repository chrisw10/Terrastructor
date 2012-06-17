using System;
using System.Collections.Generic;
using Byte.Terrastructor.Terrain.Model.Interface;

namespace Byte.Terrastructor.Terrain.Model
{
    public abstract class Repository<T> : IRepository<T>
    {
        private readonly List<T> _items = new List<T>();

        public event Action<T> ItemAdded;
        public event Action<T> ItemRemoved;

        public void Add(T item)
        {
            _items.Add(item);

            if (ItemAdded != null)
            {
                ItemAdded(item);
            }
        }

        public void Remove(T item)
        {
            if (!_items.Contains(item))
            {
                return;
            }

            _items.Remove(item);

            if (ItemRemoved != null)
            {
                ItemRemoved(item);
            }
        }

        public IEnumerable<T> Items
        {
            get { return _items; }
        }
    }
}
