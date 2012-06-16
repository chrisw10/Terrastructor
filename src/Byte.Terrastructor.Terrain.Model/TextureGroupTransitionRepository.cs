using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Byte.Terrastructor.Terrain.Model.Interface;

namespace Byte.Terrastructor.Terrain.Model
{
    public class TextureGroupTransitionRepository : ITextureGroupTransitionRepository
    {
        public event Action<TextureGroupTransition> ItemAdded;
        public event Action<TextureGroupTransition> ItemRemoved;

        public IEnumerable<TextureGroupTransition> Items
        {
            get { throw new NotImplementedException(); }
        }

        public void Add(TextureGroupTransition textureGroup)
        {
            throw new NotImplementedException();
        }

        public void Remove(TextureGroupTransition textureGroup)
        {
            throw new NotImplementedException();
        }
    }
}
