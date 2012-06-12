using System;
using NUnit.Framework;

namespace Byte.Terrastructor.Terrain.Model.Tests
{
    [TestFixture]
    public class TextureGroupRangeTest
    {
        [Test]
        public void TestCreate()
        {
            var textureGroupRange = new TextureGroupRange(0, 5);

            Assert.AreEqual(0, textureGroupRange.LowerBound);
            Assert.AreEqual(5, textureGroupRange.UpperBound);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCreateWithIncorrectUpperBound()
        {
            var textureGroupRange = new TextureGroupRange(5, 0);
        }
    }
}
