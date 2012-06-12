using System;
using System.Collections.Generic;

namespace Byte.Terrastructor.Terrain.Model
{
    public interface ITextureGroupRepository<T>
        where T : TextureGroup
    {
        event Action<T> TextureGroupAdded;
        event Action<T> TextureGroupRemoved;

        void AddTextureGroup(T textureGroup);
        void RemoveTextureGroup(T textureGroup);

        IEnumerable<T> TextureGroups { get; }
    }
}