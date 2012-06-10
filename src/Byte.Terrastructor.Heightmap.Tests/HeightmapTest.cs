using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Byte.Terrastructor.Heightmap.Tests
{
    [TestFixture]
    public class HeightmapTest
    {
        [Test]
        public void TestCreateHeightmap()
        {
            var heightmap = new Heightmap("test_create_heightmap.bmp");

            const int expectedWidth = 32;
            const int expectedHeight = 32;

            Assert.AreEqual(expectedWidth, heightmap.Width);
            Assert.AreEqual(expectedHeight, heightmap.Height);
        }

        [Test]
        public void TestHeightmapData()
        {
            var heightmap = new Heightmap("test_heightmap_data.bmp");

            const byte expectedHighByte = 255;
            const byte expectedLowByte = 0;

            Assert.AreEqual(expectedHighByte, heightmap[0, 0]);
            Assert.AreEqual(expectedHighByte, heightmap[0, 1]);
            Assert.AreEqual(expectedHighByte, heightmap[1, 0]);
            Assert.AreEqual(expectedLowByte, heightmap[1, 1]);
        }

        [Test]
        public void TestOutOfBoundsData()
        {
            var heightmap = new Heightmap("test_heightmap_data.bmp");

            const byte expectedLowByte = 0;

            Assert.AreEqual(expectedLowByte, heightmap[-1, -1]);
            Assert.AreEqual(expectedLowByte, heightmap[2, 2]);    
        }
    }
}
