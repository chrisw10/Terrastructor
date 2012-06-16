namespace Byte.Terrastructor.Terrain.Model.Interface
{
    public interface IRandomGenerator
    {
        int Generate(int min, int max);
        double Generate();
    }
}