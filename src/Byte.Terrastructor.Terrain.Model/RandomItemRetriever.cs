using System.Collections.Generic;
using System.Linq;
using Byte.Terrastructor.Terrain.Model.Interface;

namespace Byte.Terrastructor.Terrain.Model
{
    public class RandomItemRetriever<T> : IRandomItemRetriever<T> 
        where T : IProbabilityWeightedItem
    {
        private readonly IRandomGenerator _randomNumberGenerator;
        private readonly List<T> _distribution = new List<T>();

        public RandomItemRetriever(IRandomGenerator randomNumberGenerator, IEnumerable<T> items)
        {
            _randomNumberGenerator = randomNumberGenerator;
            SetupDistribution(items);
        }

        private void SetupDistribution(IEnumerable<T> items)
        {
            _distribution.Clear();

            foreach(var item in items)
            {
                _distribution.AddRange(Enumerable.Repeat(item, item.ProbabilityWeight));
            }
        }

        public T NextItem()
        {
            if(_distribution.Count == 0)
            {
                return default(T);
            }

            var next = _randomNumberGenerator.Generate(0, _distribution.Count);
            return _distribution[next];
        }
    }
}
