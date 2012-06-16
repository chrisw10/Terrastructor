using System;
using System.Collections.Generic;

namespace Byte.Terrastructor.Terrain.Model.Interface
{
    public interface ITextureGroupRepository<T> : IRepository<T> where T : TextureGroup
    {
    }
}