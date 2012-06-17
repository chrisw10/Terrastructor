using System.Collections.Generic;

namespace Byte.Terrastructor.Terrain.Model.Interface
{
    public interface ITextureGroupResolver
    {
        TextureGroup GetTextureGroupForPoint(int x, int y);
        IEnumerable<TextureGroup> TextureGroups { get; }
    }
}
