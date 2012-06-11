using System;

namespace Byte.Terrastructor.Terrain.Model
{
    public class TextureGroupRange : IEquatable<TextureGroupRange>
    {
        public int LowerBound { get; private set; }
        public int UpperBound { get; private set; }
        public TextureGroup TextureGroup { get; private set; }

        public TextureGroupRange(int lowerBound, int upperBound, TextureGroup textureGroup)
        {
            if(upperBound <= lowerBound)
            {
                throw new ArgumentOutOfRangeException("upperBound", "upperBound must be greater than lowerBound");    
            }

            LowerBound = lowerBound;
            UpperBound = upperBound;
            TextureGroup = textureGroup;
        }

        public bool Equals(TextureGroupRange other)
        {
            return !ReferenceEquals(null, other) &&
                   (ReferenceEquals(this, other) ||
                    other.LowerBound == LowerBound && other.UpperBound == UpperBound &&
                    Equals(other.TextureGroup, TextureGroup));
        }

        public override bool Equals(object obj)
        {
            return !ReferenceEquals(null, obj) &&
                   (ReferenceEquals(this, obj) ||
                    obj.GetType() == typeof (TextureGroupRange) &&
                    Equals((TextureGroupRange) obj));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = LowerBound;
                result = (result*397) ^ UpperBound;
                result = (result*397) ^ (TextureGroup != null ? TextureGroup.GetHashCode() : 0);
                return result;
            }
        }

        public static bool operator ==(TextureGroupRange left, TextureGroupRange right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TextureGroupRange left, TextureGroupRange right)
        {
            return !Equals(left, right);
        }
    }
}