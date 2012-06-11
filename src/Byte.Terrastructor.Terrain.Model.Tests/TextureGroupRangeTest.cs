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
            var textureGroup = new TextureGroup();
            var textureGroupRange = new TextureGroupRange(0, 5, textureGroup);

            Assert.AreEqual(0, textureGroupRange.LowerBound);
            Assert.AreEqual(5, textureGroupRange.UpperBound);
            Assert.AreEqual(textureGroup, textureGroupRange.TextureGroup);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCreateWithIncorrectUpperBound()
        {
            var textureGroupRange = new TextureGroupRange(5, 0, null);
        }

        [Test]
        public void TestEquals()
        {
            var textureGroup = new TextureGroup();
            var textureGroupRange = new TextureGroupRange(0, 5, textureGroup);
            var expectedTextureGroupRange = new TextureGroupRange(0, 5, textureGroup);

            Assert.AreEqual(expectedTextureGroupRange, textureGroupRange);
        }

        [Test]
        public void TestNotEquals()
        {
            var textureGroup = new TextureGroup();
            var textureGroupRange = new TextureGroupRange(0, 5, textureGroup);
            var expectedTextureGroupRange = new TextureGroupRange(0, 6, textureGroup);

            Assert.AreNotEqual(expectedTextureGroupRange, textureGroupRange);   
        }
    }
}
