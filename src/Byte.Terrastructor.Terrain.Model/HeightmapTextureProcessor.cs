using System;
using Byte.Terrastructor.Heightmap;
using Byte.Terrastructor.Terrain.Model.Interface;

namespace Byte.Terrastructor.Terrain.Model
{
    public class HeightmapTextureProcessor : ITextureProcessor
    {
        private readonly IHeightmap _heightmap;
        private readonly ITextureGroupResolver _textureGroupResolver;
        private readonly Lazy<short[,]> _textures;

        public HeightmapTextureProcessor(IHeightmap heightmap, ITextureGroupResolver textureGroupResolver)
        {
            _heightmap = heightmap;
            _textureGroupResolver = textureGroupResolver;
            _textures = new Lazy<short[,]>(InitializeTextures);
        }

        public short[,] Textures
        {
            get { return _textures.Value; }
        }

        private short[,] InitializeTextures()
        {
            return null;
        }
    }
}
