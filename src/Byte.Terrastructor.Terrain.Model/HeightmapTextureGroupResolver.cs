using System;
using Byte.Terrastructor.Heightmap;

namespace Byte.Terrastructor.Terrain.Model
{
    public class HeightmapTextureGroupResolver : ITextureGroupResolver
    {
        private IHeightmap _heightmap;

        public HeightmapTextureGroupResolver(IHeightmap heightmap)
        {
            _heightmap = heightmap;
        }

        public TextureGroup GetTextureGroupForPoint(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void AddTextureGroupRange(TextureGroupRange textureGroupRange)
        {
            throw new NotImplementedException();
        }

        public void RemoveTextureGroupRange(TextureGroupRange textureGroupRange)
        {
            throw new NotImplementedException();
        }
    }
}