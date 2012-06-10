using System;
using System.Collections.Generic;

namespace Byte.Terrastructor.Terrain.Model
{
    public class TextureGroup
    {
        private readonly HashSet<Texture> _textures = new HashSet<Texture>();

        public event Action<Texture> TextureAdded;
        public event Action<Texture> TextureRemoved;

        public IEnumerable<Texture> Textures
        {
            get
            {
                return _textures;
            }
        }

        public void AddTexture(Texture textureToAdd)
        {
            _textures.Add(textureToAdd);

            if(TextureAdded != null)
            {
                TextureAdded(textureToAdd);
            }
        }

        public void RemoveTexture(Texture textureToRemove)
        {
            _textures.Remove(textureToRemove);

            if(TextureRemoved != null)
            {
                TextureRemoved(textureToRemove);
            }
        }
    }
}
