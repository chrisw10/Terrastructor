using System;
using System.Collections.Generic;
using System.Linq;
using Byte.Terrastructor.Heightmap;

namespace Byte.Terrastructor.Terrain.Model
{
    public class HeightmapTextureGroupResolver : ITextureGroupResolver
    {
        private readonly IHeightmap _heightmap;
        private readonly List<TextureGroupRange> _textureGroupRanges = new List<TextureGroupRange>();

        public HeightmapTextureGroupResolver(IHeightmap heightmap)
        {
            _heightmap = heightmap;
        }

        public TextureGroup GetTextureGroupForPoint(int x, int y)
        {
            var height = _heightmap[x, y];
            var range = _textureGroupRanges.FirstOrDefault(textureGroupRange =>
                                                           textureGroupRange.LowerBound <= height &&
                                                           textureGroupRange.UpperBound >= height);

            return range == null ? null : range.TextureGroup;
        }

        public void AddTextureGroupRange(TextureGroupRange textureGroupRange)
        {
            _textureGroupRanges.Add(textureGroupRange);
        }

        public void RemoveTextureGroupRange(TextureGroupRange textureGroupRange)
        {
            throw new NotImplementedException();
        }
    }
}