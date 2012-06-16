using System;
using System.Collections.Generic;
using Byte.Terrastructor.Heightmap;
using Byte.Terrastructor.Terrain.Model.Interface;
using Moq;
using NUnit.Framework;

namespace Byte.Terrastructor.Terrain.Model.Tests
{
    [TestFixture]
    public class HeightmapTextureGroupResolverTest
    {
        private IHeightmap _mockHeightmap;
        private ITextureGroupRepository<TextureGroupRange> _mockTextureGroupRepository;

        [SetUp]
        public void Setup()
        {
            SetupHeightmapMock();
            SetupTextureGroupRepositoryMock();
        }

        private void SetupTextureGroupRepositoryMock()
        {
            var mock = new Mock<ITextureGroupRepository<TextureGroupRange>>();

            var textureGroupRanges = new List<TextureGroupRange>();

            mock.Setup(textureGroupRepository => textureGroupRepository.Add(It.IsAny<TextureGroupRange>()))
                .Callback((TextureGroupRange textureGroup) => textureGroupRanges.Add(textureGroup));

            mock.SetupGet(textureGroupRepository => textureGroupRepository.Items).Returns(textureGroupRanges);

            _mockTextureGroupRepository = mock.Object;
        }

        private void SetupHeightmapMock()
        {
            var mock = new Mock<IHeightmap>();
         
            mock.SetupGet(heightmap => heightmap.Height).Returns(8);
            mock.SetupGet(heightmap => heightmap.Width).Returns(8);

            var random = new Random();

            //Upper-left quadrant
            mock.Setup(heightmap => heightmap[It.IsInRange(0, 3, Range.Inclusive),
                                              It.IsInRange(0, 3, Range.Inclusive)])
                .Returns(() => random.Next(0, 50));

            //Upper-right quadrant
            mock.Setup(heightmap => heightmap[It.IsInRange(4, 7, Range.Inclusive),
                                              It.IsInRange(0, 3, Range.Inclusive)])
                .Returns(() => random.Next(51, 150));

            //Lower-left quadrant
            mock.Setup(heightmap => heightmap[It.IsInRange(0, 3, Range.Inclusive),
                                              It.IsInRange(4, 7, Range.Inclusive)])
                .Returns(() => random.Next(151, 200));

            //Lower-right quadrant
            mock.Setup(heightmap => heightmap[It.IsInRange(4, 7, Range.Inclusive),
                                              It.IsInRange(4, 7, Range.Inclusive)])
                .Returns(() => random.Next(201, 255));

            _mockHeightmap = mock.Object;
        }

        [Test]
        public void TestGetTextureGroupForPoint()
        {
            var textureGroupResolver = new HeightmapTextureGroupResolver(_mockHeightmap, _mockTextureGroupRepository);
            var upperLeftTextureGroup = new TextureGroupRange(0, 50);
            var upperRightTextureGroup = new TextureGroupRange(51, 150);
            var lowerLeftTextureGroup = new TextureGroupRange(151, 200);
            var lowerRightTextureGroup = new TextureGroupRange(201, 255);

            _mockTextureGroupRepository.Add(upperLeftTextureGroup);
            _mockTextureGroupRepository.Add(upperRightTextureGroup);
            _mockTextureGroupRepository.Add(lowerLeftTextureGroup);
            _mockTextureGroupRepository.Add(lowerRightTextureGroup);


            var textureGroup = textureGroupResolver.GetTextureGroupForPoint(0, 0);
            Assert.AreSame(upperLeftTextureGroup, textureGroup);

            textureGroup = textureGroupResolver.GetTextureGroupForPoint(5, 0);
            Assert.AreSame(upperRightTextureGroup, textureGroup);

            textureGroup = textureGroupResolver.GetTextureGroupForPoint(0, 5);
            Assert.AreSame(lowerLeftTextureGroup, textureGroup);

            textureGroup = textureGroupResolver.GetTextureGroupForPoint(5, 5);
            Assert.AreSame(lowerRightTextureGroup, textureGroup);
        }

        [Test]
        public void TestGetTextureGroupForInvalidPoint()
        {
            var textureGroupResolver = new HeightmapTextureGroupResolver(_mockHeightmap, _mockTextureGroupRepository);
            var upperLeftTextureGroup = new TextureGroupRange(0, 50);
            var upperRightTextureGroup = new TextureGroupRange(51, 150);
            var lowerLeftTextureGroup = new TextureGroupRange(151, 200);
            var lowerRightTextureGroup = new TextureGroupRange(201, 255);

            _mockTextureGroupRepository.Add(upperLeftTextureGroup);
            _mockTextureGroupRepository.Add(upperRightTextureGroup);
            _mockTextureGroupRepository.Add(lowerLeftTextureGroup);
            _mockTextureGroupRepository.Add(lowerRightTextureGroup);

            var textureGroup = textureGroupResolver.GetTextureGroupForPoint(-5, -5);
            Assert.AreSame(upperLeftTextureGroup, textureGroup);

            textureGroup = textureGroupResolver.GetTextureGroupForPoint(10, 10);
            Assert.AreSame(upperLeftTextureGroup, textureGroup);
        }
    }
}
