using System;
using System.Collections.Generic;

namespace Byte.Terrastructor.Terrain.Model.Interface
{
    public interface IRepository<T>
    {
        event Action<T> ItemAdded;
        event Action<T> ItemRemoved;
        IEnumerable<T> Items { get; }
        void Add(T item);
        void Remove(T item);
    }
}