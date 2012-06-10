namespace Byte.Terrastructor.Heightmap
{
    /// <summary>
    /// Used to implement different heightmap sources.  Examples include bitmap sources or DEM sources.
    /// </summary>
    public interface IHeightmap
    {
        int Width { get; }
        int Height { get; }
        int this[int x, int y] { get; }
    }
}