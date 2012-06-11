﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Byte.Terrastructor.Terrain.Model
{
    public interface ITextureGroupResolver
    {
        TextureGroup GetTextureGroupForPoint(int x, int y);
    }
}
