using System.Collections.Generic;
using Byte.Terrastructor.Heightmap;
using Byte.Terrastructor.Terrain.Model.Interface;
using Moq;
using NUnit.Framework;

namespace Byte.Terrastructor.Terrain.Model.Tests
{
    [TestFixture]
    public class HeightmapTextureGroupProcessorTest
    {
        private IHeightmap _mockHeightmap;
        private ITextureGroupResolver _mockTextureGroupResolver;
        private ITextureGroupTransitionRepository _textureGroupTransitionRepository;

        [SetUp]
        public void Setup()
        {
            SetupHeightmap();
            SetupTextureGroupResolver();
            SetupTextureTransitionGroupRepository();
        }

        private void SetupTextureTransitionGroupRepository()
        {
            var mock = new Mock<ITextureGroupTransitionRepository>();

            var textureGroupTransitions = new List<TextureGroupTransition>
                                              {
                                                  new TextureGroupTransition
                                                      {
                                                          LowerGroupName = "Lower",
                                                          UpperGroupName = "Upper"
                                                      }
                                              };

            mock.SetupGet(repository => repository.Items)
                .Returns(textureGroupTransitions);

            _textureGroupTransitionRepository = mock.Object;
        }

        private void SetupTextureGroupResolver()
        {
            var mock = new Mock<ITextureGroupResolver>();

            //TODO: This will need to be update to be range groups.
            var textures = new List<TextureGroup>
                               {
                                   new TextureGroup
                                       {
                                           Name = "Lower"
                                       },
                                   new TextureGroup
                                       {
                                           Name = "Upper"
                                       }
                               };

            mock.SetupGet(groupResolver => groupResolver.TextureGroups)
                .Returns(textures);

            _mockTextureGroupResolver = mock.Object;
        }

        private void SetupHeightmap()
        {
            const int width = 3;
            const int height = 3;

            var mock = new Mock<IHeightmap>();

            mock.SetupGet(heightmap => heightmap.Width).Returns(width);
            mock.SetupGet(heightmap => heightmap.Height).Returns(height);

            for (int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    int xPosition = x;
                    int yPosition = y;

                    if (xPosition < (width - 1) && yPosition < (height - 1))
                    {
                        mock.SetupGet(heightmap => heightmap[xPosition, yPosition])
                            .Returns(0);
                    }
                    else
                    {
                        mock.SetupGet(heightmap => heightmap[xPosition, yPosition])
                            .Returns(2);
                    }     
                }
            }

                _mockHeightmap = mock.Object;
        }

        [Test]
        public void TestTextures()
        {
            var textureGroupProcessor = new HeightmapTextureProcessor(_mockHeightmap, _mockTextureGroupResolver, _textureGroupTransitionRepository);

            var textures = textureGroupProcessor.Textures;
        }
    }
}
