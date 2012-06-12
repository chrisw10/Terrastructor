using System;
using System.Linq;
using Byte.Terrastructor.Heightmap;

namespace Byte.Terrastructor.Terrain.Model
{
    public class HeightmapTextureGroupResolver : ITextureGroupResolver
    {
        private readonly IHeightmap _heightmap;
        private readonly ITextureGroupRepository<TextureGroupRange> _textureGroupRepository;

        public HeightmapTextureGroupResolver(IHeightmap heightmap, ITextureGroupRepository<TextureGroupRange> textureGroupRepository)
        {
            if(heightmap == null)
            {
                throw new ArgumentNullException("heightmap");
            }

            if(textureGroupRepository == null)
            {
                throw new ArgumentNullException("textureGroupRepository");
            }

            _heightmap = heightmap;
            _textureGroupRepository = textureGroupRepository;
        }

        public TextureGroup GetTextureGroupForPoint(int x, int y)
        {
            var height = _heightmap[x, y];
            var range = _textureGroupRepository.TextureGroups.FirstOrDefault(textureGroupRange =>
                                                                             textureGroupRange.LowerBound <= height &&
                                                                             textureGroupRange.UpperBound >= height);

            return range;
        }
    }
}