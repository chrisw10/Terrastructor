using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Byte.Terrastructor.Heightmap.Tests
{
    [TestFixture]
    public class BitmapHeightmapTest
    {
        [Test]
        public void TestCreateHeightmap()
        {
            var heightmap = new BitmapHeightmap("test_create_heightmap.bmp");

            const int expectedWidth = 32;
            const int expectedHeight = 32;

            Assert.AreEqual(expectedWidth, heightmap.Width);
            Assert.AreEqual(expectedHeight, heightmap.Height);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCreateHeightmapWithException()
        {
            var heightmap = new BitmapHeightmap("file_not_found.jpg");
        }

        [Test]
        public void TestHeightmapData()
        {
            var heightmap = new BitmapHeightmap("test_heightmap_data.bmp");

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
            var heightmap = new BitmapHeightmap("test_heightmap_data.bmp");

            const byte expectedLowByte = 0;

            Assert.AreEqual(expectedLowByte, heightmap[-1, -1]);
            Assert.AreEqual(expectedLowByte, heightmap[heightmap.Width, heightmap.Height]);    
        }
    }
}
