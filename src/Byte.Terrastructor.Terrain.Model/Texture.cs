using System;
using Byte.Terrastructor.Terrain.Model.Interface;

namespace Byte.Terrastructor.Terrain.Model.Interface
{
}

namespace Byte.Terrastructor.Terrain.Model
{
    public class Texture : IEquatable<Texture>, IProbabilityWeighted
    {
        public Texture(int number, double probabilityWeight, Rotation rotation)
        {
            Number = number;
            ProbabilityWeight = probabilityWeight;
            Rotation = rotation;
        }

        public int Number { get; private set; }
        public double ProbabilityWeight { get; private set; }
        public Rotation Rotation { get; private set; }

        public bool Equals(Texture other)
        {
            return !ReferenceEquals(null, other) &&
                   (ReferenceEquals(this, other) ||
                    other.Number == Number &&
                    other.ProbabilityWeight.Equals(ProbabilityWeight) &&
                    Equals(other.Rotation, Rotation));
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
                result = (result*397) ^ Rotation.GetHashCode();
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