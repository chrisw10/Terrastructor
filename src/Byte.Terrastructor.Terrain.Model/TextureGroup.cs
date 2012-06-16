using System;
using System.Collections.Generic;
using Byte.Terrastructor.Terrain.Model.Interface;

namespace Byte.Terrastructor.Terrain.Model
{
    public class TextureGroup : IRepository<Texture>
    {
        private readonly HashSet<Texture> _items = new HashSet<Texture>();

        public event Action<Texture> ItemAdded;
        public event Action<Texture> ItemRemoved;

        public string Name { get; set; }

        public IEnumerable<Texture> Items
        {
            get
            {
                return _items;
            }
        }

        public void Add(Texture textureToAdd)
        {
            _items.Add(textureToAdd);

            if(ItemAdded != null)
            {
                ItemAdded(textureToAdd);
            }
        }

        public void Remove(Texture textureToRemove)
        {
            if(!_items.Contains(textureToRemove))
            {
                return;
            }

            _items.Remove(textureToRemove);

            if(ItemRemoved != null)
            {
                ItemRemoved(textureToRemove);
            }
        }
    }
}
