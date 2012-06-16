using System;
using System.Collections.Generic;
using Byte.Terrastructor.Terrain.Model.Interface;

namespace Byte.Terrastructor.Terrain.Model
{
    //TODO:  Think about this some more.  Is this really the right way?
    //You're looking for something that's a bit more polymorphic (i.e. you can swap this out easily).
    //Maybe you swap out the view models at the top level according to the mode the user selects?
    public class TextureGroupRangeRepository : ITextureGroupRepository<TextureGroupRange>
    {
        private readonly List<TextureGroupRange> _itemRanges = new List<TextureGroupRange>();

        public event Action<TextureGroupRange> ItemAdded;
        public event Action<TextureGroupRange> ItemRemoved;

        public void Add(TextureGroupRange textureGroup)
        {
            _itemRanges.Add(textureGroup);

            if(ItemAdded != null)
            {
                ItemAdded(textureGroup);
            }
        }

        public void Remove(TextureGroupRange textureGroup)
        {
            if (!_itemRanges.Contains(textureGroup))
            {
                return;
            }

            _itemRanges.Remove(textureGroup);

            if (ItemRemoved != null)
            {
                ItemRemoved(textureGroup);
            }
        }

        public IEnumerable<TextureGroupRange> Items
        {
            get { return _itemRanges; }
        }
    }
}
