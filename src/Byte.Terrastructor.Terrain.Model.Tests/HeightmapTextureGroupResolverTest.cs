using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Byte.Terrastructor.Heightmap;
using Moq;
using NUnit.Framework;

namespace Byte.Terrastructor.Terrain.Model.Tests
{
    [TestFixture]
    public class HeightmapTextureGroupResolverTest
    {
        private IHeightmap _mockHeightmap;

        [SetUp]
        public void Setup()
        {
            var mock = new Mock<IHeightmap>();
         
            mock.SetupGet(heightmap => heightmap.Height).Returns(8);
            mock.SetupGet(heightmap => heightmap.Width).Returns(8);

            var random = new Random();

            //Upper-left quadrant
            mock.Setup(heightmap => heightmap[It.IsInRange(0, 3, Range.Inclusive), It.IsInRange(0, 3, Range.Inclusive)])
                .Returns(() => random.Next(0, 50));

            //Upper-right quadrant
            mock.Setup(heightmap => heightmap[It.IsInRange(4, 7, Range.Inclusive), It.IsInRange(0, 3, Range.Inclusive)])
                .Returns(() => random.Next(51, 150));

            //Lower-left quadrant
            mock.Setup(heightmap => heightmap[It.IsInRange(0, 3, Range.Inclusive), It.IsInRange(4, 7, Range.Inclusive)])
                .Returns(() => random.Next(151, 200));

            //Lower-right quadrant
            mock.Setup(heightmap => heightmap[It.IsInRange(4, 7, Range.Inclusive), It.IsInRange(4, 7, Range.Inclusive)])
                .Returns(() => random.Next(201, 255));

            _mockHeightmap = mock.Object;
        }

        [Test]
        public void TestGetTextureGroupForPoint()
        {
            var textureGroupResolver = new HeightmapTextureGroupResolver(_mockHeightmap);

            var textureGroup = textureGroupResolver.GetTextureGroupForPoint(0, 0);
        }
    }
}
