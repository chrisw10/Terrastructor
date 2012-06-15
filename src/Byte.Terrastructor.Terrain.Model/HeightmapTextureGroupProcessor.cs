using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Byte.Terrastructor.Heightmap;

namespace Byte.Terrastructor.Terrain.Model
{
    public class HeightmapTextureGroupProcessor
    {
        private readonly IHeightmap _heightmap;
        private readonly ITextureGroupResolver _textureGroupResolver;

        public HeightmapTextureGroupProcessor(IHeightmap heightmap, ITextureGroupResolver textureGroupResolver)
        {
            _heightmap = heightmap;
            _textureGroupResolver = textureGroupResolver;
        }
    }
}
