using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Byte.Terrastructor.Terrain.Model.Tests
{
    [TestFixture]
    public class TextureGroupRangeRepositoryTest
    {
        [Test]
        public void TestAddTextureGroup()
        {
            var textureGroupRangeRepository = new TextureGroupRangeRepository();
            var textureGroupRange = new TextureGroupRange(0, 5);

            textureGroupRangeRepository.Add(textureGroupRange);

            Assert.IsTrue(textureGroupRangeRepository.Items.Contains(textureGroupRange));
        }

        [Test]
        public void TestRemoveTextureGroup()
        {
            var textureGroupRangeRepository = new TextureGroupRangeRepository();
            var textureGroupRange = new TextureGroupRange(0, 5);

            textureGroupRangeRepository.Add(textureGroupRange);
            textureGroupRangeRepository.Remove(textureGroupRange);

            Assert.IsFalse(textureGroupRangeRepository.Items.Contains(textureGroupRange));            
        }

        [Test]
        public void TestRemoveInvalidTextureGroup()
        {
            var textureGroupRangeRepository = new TextureGroupRangeRepository();
            var textureGroupRange = new TextureGroupRange(0, 5);
            var invalidGroupRange = new TextureGroupRange(6, 10);

            textureGroupRangeRepository.Add(textureGroupRange);
            textureGroupRangeRepository.Remove(invalidGroupRange);

            Assert.IsTrue(textureGroupRangeRepository.Items.Contains(textureGroupRange));
            Assert.IsFalse(textureGroupRangeRepository.Items.Contains(invalidGroupRange));  
        }

        [Test]
        public void TestTextureGroupAddedEvent()
        {
            var textureGroupRangeRepository = new TextureGroupRangeRepository();
            var textureGroup = new TextureGroupRange(0, 5);
            var wasTextureGroupAdded = false;

            textureGroupRangeRepository.ItemAdded += addedTextureGroup => wasTextureGroupAdded = addedTextureGroup.Equals(textureGroup);
            textureGroupRangeRepository.Add(textureGroup);

            Assert.IsTrue(wasTextureGroupAdded); 
        }

        [Test]
        public void TestTextureGroupRemovedEvent()
        {
            var textureGroupRangeRepository = new TextureGroupRangeRepository();
            var textureGroup = new TextureGroupRange(0, 5);
            var wasTextureGroupRemoved = false;

            textureGroupRangeRepository.ItemRemoved += removedTextureGroup => wasTextureGroupRemoved = removedTextureGroup.Equals(textureGroup);
            textureGroupRangeRepository.Add(textureGroup);
            textureGroupRangeRepository.Remove(textureGroup);

            Assert.IsTrue(wasTextureGroupRemoved);  
        }

        [Test]
        public void TestTextureGroupRemovedEventWithInvalidTextureGroup()
        {
            var textureGroupRangeRepository = new TextureGroupRangeRepository();
            var textureGroup = new TextureGroupRange(0, 5);
            var invalidGroup = new TextureGroupRange(6, 10);
            var wasTextureGroupRemoved = false;

            textureGroupRangeRepository.ItemRemoved += removedTextureGroup => wasTextureGroupRemoved = removedTextureGroup.Equals(invalidGroup);
            textureGroupRangeRepository.Add(textureGroup);
            textureGroupRangeRepository.Remove(invalidGroup);

            Assert.IsFalse(wasTextureGroupRemoved);
        }
    }
}
