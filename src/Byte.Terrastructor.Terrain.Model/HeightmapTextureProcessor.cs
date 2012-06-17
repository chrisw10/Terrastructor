using System;
using System.Collections.Generic;
using System.Linq;
using Byte.Terrastructor.Heightmap;
using Byte.Terrastructor.Terrain.Model.Interface;

namespace Byte.Terrastructor.Terrain.Model
{
    public class HeightmapTextureProcessor : ITextureProcessor
    {
        private readonly IHeightmap _heightmap;
        private readonly ITextureGroupResolver _textureGroupResolver;
        private readonly ITextureGroupTransitionRepository _textureGroupTransitionRepository;
        private readonly Lazy<short[,]> _textures;

        public HeightmapTextureProcessor(IHeightmap heightmap,
                                         ITextureGroupResolver textureGroupResolver,
                                         ITextureGroupTransitionRepository textureGroupTransitionRepository)
        {
            _heightmap = heightmap;
            _textureGroupResolver = textureGroupResolver;
            _textureGroupTransitionRepository = textureGroupTransitionRepository;
            _textures = new Lazy<short[,]>(InitializeTextures);
        }

        public short[,] Textures
        {
            get { return _textures.Value; }
        }

        private short[,] InitializeTextures()
        {
            var textureGroupIds = GetTextureGroupIds();
            var textureTansitionLookup = GetTextureTransitionLookup(textureGroupIds);
            var textureGroupMap = ProcessHeightmapToTextureGroupIds(textureGroupIds);

            return BuildTextureMap(textureGroupIds, textureTansitionLookup, textureGroupMap);
        }

        private short[,] BuildTextureMap(IDictionary<TextureGroup, byte> textureGroupIds,
                                         IDictionary<Tuple<byte, byte>, TextureGroupTransition> textureTansitionLookup, 
                                         byte[,] textureGroupMap)
        {
            //TODO: Logic!

            return null;
        }

        private byte[,] ProcessHeightmapToTextureGroupIds(IDictionary<TextureGroup, byte> textureGroupIds)
        {
            var width = _heightmap.Width;
            var height = _heightmap.Height;
            var result = new byte[width, height];

            for(int x = 0; x < width; ++x)
            {
                for(int y = 0; y < height; ++y)
                {
                    result[x, y] = textureGroupIds[_textureGroupResolver.GetTextureGroupForPoint(x, y)];
                }
            }

            return result;
        }

        private IDictionary<Tuple<byte, byte>, TextureGroupTransition> GetTextureTransitionLookup(IEnumerable<KeyValuePair<TextureGroup, byte>> textureGroupIds)
        {
            return (from leftKvp in textureGroupIds
                    join transitionGroup in _textureGroupTransitionRepository.Items
                        on leftKvp.Key.Name equals transitionGroup.LowerGroupName
                    join rightKvp in textureGroupIds
                        on transitionGroup.UpperGroupName equals rightKvp.Key.Name
                    select new
                               {
                                   Key = Tuple.Create(leftKvp.Value, rightKvp.Value),
                                   Value = transitionGroup
                               })
                .ToDictionary(item => item.Key, item => item.Value);

        }

        private IDictionary<TextureGroup, byte> GetTextureGroupIds()
        {
            return _textureGroupResolver.TextureGroups
                                        .Select((group, index) => new { group, index })
                                        .ToDictionary(group => group.group, group => (byte)group.index);
        }
    }
}
