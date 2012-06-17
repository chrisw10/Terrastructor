namespace Byte.Terrastructor.Terrain.Model
{
    public class TextureGroupTransition
    {
        public string LowerGroupName { get; set; }
        public string UpperGroupName { get; set; }

        public TextureGroup StraightEdges { get; set; }
        public TextureGroup ConcaveCorners { get; set; }
        public TextureGroup ConvexCorners { get; set; }
    }
}
