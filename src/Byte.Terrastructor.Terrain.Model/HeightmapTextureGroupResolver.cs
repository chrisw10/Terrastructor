using System;
using System.Collections.Generic;
using System.Linq;
using Byte.Terrastructor.Heightmap;
using Byte.Terrastructor.Terrain.Model.Interface;

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
            var range = _textureGroupRepository.Items.FirstOrDefault(textureGroupRange =>
                                                                             textureGroupRange.LowerBound <= height &&
                                                                             textureGroupRange.UpperBound >= height);

            return range;
        }

        public IEnumerable<TextureGroup> TextureGroups
        {
            get { return _textureGroupRepository.Items; }
        }
    }
}