using System;
using Byte.Terrastructor.Terrain.Model.Interface;

namespace Byte.Terrastructor.Terrain.Model
{
    public class Texture : IEquatable<Texture>, IProbabilityWeightedItem
    {
        public Texture(int number, int probabilityWeight, TextureRotation textureRotation)
        {
            Number = number;
            ProbabilityWeight = probabilityWeight;
            TextureRotation = textureRotation;
        }

        public int Number { get; private set; }
        public int ProbabilityWeight { get; private set; }
        public TextureRotation TextureRotation { get; private set; }

        public bool Equals(Texture other)
        {
            return !ReferenceEquals(null, other) &&
                   (ReferenceEquals(this, other) ||
                    other.Number == Number &&
                    other.ProbabilityWeight.Equals(ProbabilityWeight) &&
                    Equals(other.TextureRotation, TextureRotation));
        }

        public override bool Equals(object obj)
        {
            return !ReferenceEquals(null, obj) &&
                   (ReferenceEquals(this, obj) ||
                    obj.GetType() == typeof (Texture) && Equals((Texture) obj));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Number;
                result = (result*397) ^ ProbabilityWeight.GetHashCode();
                result = (result*397) ^ TextureRotation.GetHashCode();
                return result;
            }
        }

        public static bool operator ==(Texture left, Texture right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Texture left, Texture right)
        {
            return !Equals(left, right);
        }
    }
}