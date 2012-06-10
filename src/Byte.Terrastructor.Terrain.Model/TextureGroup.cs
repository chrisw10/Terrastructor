using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Byte.Terrastructor.Terrain.Model
{
    public class TextureGroup
    {
        private readonly List<Texture> _textures = new List<Texture>();

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
        }

        public void RemoveTexture(Texture textureToRemove)
        {
            _textures.Remove(textureToRemove);
        }
    }
}
