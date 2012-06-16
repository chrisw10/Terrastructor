namespace Byte.Terrastructor.Terrain.Model.Interface
{
    public interface IRandomItemRetriever<out T> where T : IProbabilityWeightedItem
    {
        T NextItem();
    }
}