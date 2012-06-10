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
            var texture = new Texture(0, 0, Rotation.Any);

            var textureGroup = new TextureGroup();
            textureGroup.AddTexture(texture);

            Assert.IsTrue(textureGroup.Textures.Contains(texture));
        }

        [Test]
        public void TestTextureRemove()
        {
            var texture = new Texture(0, 0, Rotation.Any);
            var textureGroup = new TextureGroup();
            textureGroup.AddTexture(texture);

            textureGroup.RemoveTexture(texture);

            Assert.IsFalse(textureGroup.Textures.Contains(texture));
        }

        [Test]
        public void TestTextureAddedEvent()
        {
            var texture = new Texture(0, 0, Rotation.Any);
            var textureGroup = new TextureGroup();
            var wasTextureAdded = false;

            textureGroup.TextureAdded += addedTexture => wasTextureAdded = addedTexture == texture;

            textureGroup.AddTexture(texture);

            Assert.IsTrue(wasTextureAdded);
        }

        [Test]
        public void TestTextureRemovedEvent()
        {
            var texture = new Texture(0, 0, Rotation.Any);
            var textureGroup = new TextureGroup();
            var wasTextureRemoved = false;

            textureGroup.TextureRemoved += addedTexture => wasTextureRemoved = addedTexture == texture;

            textureGroup.AddTexture(texture);
            textureGroup.RemoveTexture(texture);

            Assert.IsTrue(wasTextureRemoved); 
        }
    }
}
