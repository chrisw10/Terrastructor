using System;

namespace Byte.Terrastructor.Terrain.Model
{
    public class TextureGroupRange : TextureGroup
    {
        public int LowerBound { get; private set; }
        public int UpperBound { get; private set; }

        public TextureGroupRange(int lowerBound, int upperBound)
        {
            if(upperBound <= lowerBound)
            {
                throw new ArgumentOutOfRangeException("upperBound", "upperBound must be greater than lowerBound");   
            }

            LowerBound = lowerBound;
            UpperBound = upperBound;
        }
    }
}