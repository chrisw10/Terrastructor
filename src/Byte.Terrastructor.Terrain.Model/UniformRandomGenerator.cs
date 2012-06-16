using System;
using Byte.Terrastructor.Terrain.Model.Interface;

namespace Byte.Terrastructor.Terrain.Model
{
    public class UniformRandomGenerator : IRandomGenerator
    {
        private readonly Random _random;

        public UniformRandomGenerator(int seed)
        {
            _random = new Random(seed);        
        }

        public int Generate(int min, int max)
        {
            return _random.Next(min, max);
        }

        public double Generate()
        {
            return _random.NextDouble();
        }
    }
}