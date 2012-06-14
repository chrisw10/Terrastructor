using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Byte.Terrastructor.Terrain.Model
{
    //TODO:  Think about this some more.  Is this really the right way?
    //You're looking for something that's a bit more polymorphic (i.e. you can swap this out easily).
    //Maybe you swap out the view models at the top level according to the mode the user selects?
    public class TextureGroupRangeRepository : ITextureGroupRepository<TextureGroupRange>
    {
        private readonly List<TextureGroupRange> _textureGroupRanges = new List<TextureGroupRange>();

        public event Action<TextureGroupRange> TextureGroupAdded;
        public event Action<TextureGroupRange> TextureGroupRemoved;

        public void AddTextureGroup(TextureGroupRange textureGroup)
        {
            _textureGroupRanges.Add(textureGroup);

            if(TextureGroupAdded != null)
            {
                TextureGroupAdded(textureGroup);
            }
        }

        public void RemoveTextureGroup(TextureGroupRange textureGroup)
        {
            if (!_textureGroupRanges.Contains(textureGroup))
            {
                return;
            }

            _textureGroupRanges.Remove(textureGroup);

            if (TextureGroupRemoved != null)
            {
                TextureGroupRemoved(textureGroup);
            }
        }

        public IEnumerable<TextureGroupRange> TextureGroups
        {
            get { return _textureGroupRanges; }
        }
    }
}
