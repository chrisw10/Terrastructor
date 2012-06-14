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

            textureGroupRangeRepository.AddTextureGroup(textureGroupRange);

            Assert.IsTrue(textureGroupRangeRepository.TextureGroups.Contains(textureGroupRange));
        }

        [Test]
        public void TestRemoveTextureGroup()
        {
            var textureGroupRangeRepository = new TextureGroupRangeRepository();
            var textureGroupRange = new TextureGroupRange(0, 5);

            textureGroupRangeRepository.AddTextureGroup(textureGroupRange);
            textureGroupRangeRepository.RemoveTextureGroup(textureGroupRange);

            Assert.IsFalse(textureGroupRangeRepository.TextureGroups.Contains(textureGroupRange));            
        }

        [Test]
        public void TestRemoveInvalidTextureGroup()
        {
            var textureGroupRangeRepository = new TextureGroupRangeRepository();
            var textureGroupRange = new TextureGroupRange(0, 5);
            var invalidGroupRange = new TextureGroupRange(6, 10);

            textureGroupRangeRepository.AddTextureGroup(textureGroupRange);
            textureGroupRangeRepository.RemoveTextureGroup(invalidGroupRange);

            Assert.IsTrue(textureGroupRangeRepository.TextureGroups.Contains(textureGroupRange));
            Assert.IsFalse(textureGroupRangeRepository.TextureGroups.Contains(invalidGroupRange));  
        }

        [Test]
        public void TestTextureGroupAddedEvent()
        {
            var textureGroupRangeRepository = new TextureGroupRangeRepository();
            var textureGroup = new TextureGroupRange(0, 5);
            var wasTextureGroupAdded = false;

            textureGroupRangeRepository.TextureGroupAdded += addedTextureGroup => wasTextureGroupAdded = addedTextureGroup.Equals(textureGroup);
            textureGroupRangeRepository.AddTextureGroup(textureGroup);

            Assert.IsTrue(wasTextureGroupAdded); 
        }

        [Test]
        public void TestTextureGroupRemovedEvent()
        {
            var textureGroupRangeRepository = new TextureGroupRangeRepository();
            var textureGroup = new TextureGroupRange(0, 5);
            var wasTextureGroupRemoved = false;

            textureGroupRangeRepository.TextureGroupRemoved += removedTextureGroup => wasTextureGroupRemoved = removedTextureGroup.Equals(textureGroup);
            textureGroupRangeRepository.AddTextureGroup(textureGroup);
            textureGroupRangeRepository.RemoveTextureGroup(textureGroup);

            Assert.IsTrue(wasTextureGroupRemoved);  
        }

        [Test]
        public void TestTextureGroupRemovedEventWithInvalidTextureGroup()
        {
            var textureGroupRangeRepository = new TextureGroupRangeRepository();
            var textureGroup = new TextureGroupRange(0, 5);
            var invalidGroup = new TextureGroupRange(6, 10);
            var wasTextureGroupRemoved = false;

            textureGroupRangeRepository.TextureGroupRemoved += removedTextureGroup => wasTextureGroupRemoved = removedTextureGroup.Equals(invalidGroup);
            textureGroupRangeRepository.AddTextureGroup(textureGroup);
            textureGroupRangeRepository.RemoveTextureGroup(invalidGroup);

            Assert.IsFalse(wasTextureGroupRemoved);
        }
    }
}
