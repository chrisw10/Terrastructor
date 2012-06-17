using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Byte.Terrastructor.Terrain.Model.Tests
{
    [TestFixture]
    public class TextureGroupTest
    {
        [Test]
        public void TestTextureAdd()
        {
            var texture = new Texture(0, 0, TextureRotation.Any);

            var textureGroup = new TextureGroup();
            textureGroup.Add(texture);

            Assert.IsTrue(textureGroup.Items.Contains(texture));
        }

        [Test]
        public void TestTextureRemove()
        {
            var texture = new Texture(0, 0, TextureRotation.Any);
            var textureGroup = new TextureGroup();
            textureGroup.Add(texture);

            textureGroup.Remove(texture);

            Assert.IsFalse(textureGroup.Items.Contains(texture));
        }

        [Test]
        public void TestTextureAddedEvent()
        {
            var texture = new Texture(0, 0, TextureRotation.Any);
            var textureGroup = new TextureGroup();
            var wasTextureAdded = false;

            textureGroup.ItemAdded += addedTexture => wasTextureAdded = addedTexture == texture;

            textureGroup.Add(texture);

            Assert.IsTrue(wasTextureAdded);
        }

        [Test]
        public void TestTextureRemovedEvent()
        {
            var texture = new Texture(0, 0, TextureRotation.Any);
            var textureGroup = new TextureGroup();
            var wasTextureRemoved = false;

            textureGroup.ItemRemoved += addedTexture => wasTextureRemoved = addedTexture == texture;

            textureGroup.Add(texture);
            textureGroup.Remove(texture);

            Assert.IsTrue(wasTextureRemoved); 
        }
    }
}
