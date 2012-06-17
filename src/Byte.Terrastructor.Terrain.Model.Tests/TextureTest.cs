using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Byte.Terrastructor.Terrain.Model.Tests
{
    [TestFixture]
    public class TextureTest
    {
        [Test]
        public void TestCreate()
        {
            var texture = new Texture(0, 1, TextureRotation.Any);

            Assert.AreEqual(0, texture.Number);
            Assert.AreEqual(1, texture.ProbabilityWeight);
            Assert.AreEqual(TextureRotation.Any, texture.TextureRotation);
        }

        [Test]
        public void TestEquals()
        {
            var firstTexture = new Texture(0, 1, TextureRotation.Any);
            var secondTexture = new Texture(0, 1, TextureRotation.Any);

            Assert.AreEqual(firstTexture, secondTexture);
        }

        [Test]
        public void TestNotEquals()
        {
            var firstTexture = new Texture(0, 1, TextureRotation.Any);
            var secondTexture = new Texture(1, 0, TextureRotation.North);

            Assert.AreNotEqual(firstTexture, secondTexture);
        }
    }
}
