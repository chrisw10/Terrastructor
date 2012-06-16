using System;
using System.Collections.Generic;
using System.Linq;
using Byte.Terrastructor.Terrain.Model.Interface;
using Moq;
using NUnit.Framework;

namespace Byte.Terrastructor.Terrain.Model.Tests
{
    [TestFixture]
    public class RandomItemRetrieverTest
    {
        private IRandomGenerator _randomGenerator;

        [SetUp]
        public void Setup()
        {
            SetupRandomGenerator();
        }

        private void SetupRandomGenerator()
        {
            var mock = new Mock<IRandomGenerator>();
            int counter = 0;

            mock.Setup(randomGenerator => randomGenerator.Generate(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int min, int max) => unchecked(counter++)%(max - min) + min);

            _randomGenerator = mock.Object;
        }

        private static IProbabilityWeightedItem GenerateItem(int probabilityWeight)
        {
            var mockItem = new Mock<IProbabilityWeightedItem>();

            mockItem.SetupGet(item => item.ProbabilityWeight)
                .Returns(probabilityWeight);

            return mockItem.Object;
        }

        private static IEnumerable<IProbabilityWeightedItem> GetUniformlyDistributedItems(int count)
        {
            for(int counter = 0; counter < count; ++counter)
            {
                yield return GenerateItem(1);
            }
        }

        private static IEnumerable<IProbabilityWeightedItem> GetNonUniformlyDistributedItems(int count)
        {
            for (int counter = 0; counter < count; ++counter)
            {
                yield return GenerateItem(counter + 1);
            }
        }

        [Test]
        public void TestGetRandomItemsInUniformDistribution()
        {
            var items = GetUniformlyDistributedItems(10).ToList();
            var randomItemRetriever = new RandomItemRetriever<IProbabilityWeightedItem>(_randomGenerator, items);

            var actualItems = Enumerable.Range(0, 10)
                                        .Select(counter => randomItemRetriever.NextItem())
                                        .ToList();

            Assert.IsTrue(items.SequenceEqual(actualItems));
        }

        [Test]
        public void TestGetRandomItemsInNonUniformDistribution()
        {
            var items = GetNonUniformlyDistributedItems(10).ToList();
            var randomItemRetriever = new RandomItemRetriever<IProbabilityWeightedItem>(_randomGenerator, items);

            var actualItems = Enumerable.Range(0, 10)
                            .Select(counter => randomItemRetriever.NextItem())
                            .ToList();

            var expectedItems = new List<IProbabilityWeightedItem>
                                    {
                                        items[0],
                                        items[1],
                                        items[1],
                                        items[2],
                                        items[2],
                                        items[2],
                                        items[3],
                                        items[3],
                                        items[3],
                                        items[3]
                                    };

            Assert.IsTrue(expectedItems.SequenceEqual(actualItems));
        }
    }
}
