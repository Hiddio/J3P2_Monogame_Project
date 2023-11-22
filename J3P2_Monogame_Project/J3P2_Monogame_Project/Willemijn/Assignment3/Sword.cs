using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P2_Monogame_Project.Willemijn.Assignment3
{
    public class Sword : GameObject
    {
        private Knight _knight;
        public Sword(SceneManager sceneManager, Vector2 position, GraphicsDeviceManager graphics, Texture2D texture, Knight knight) : base(sceneManager, position, graphics, texture)
        {
            _knight = knight;
        }

        public override void Update(GameTime gameTime)
        {

            float distancePlayer = Vector2.Distance(_position, _knight._position);
            
            if (distancePlayer < _knight._textureKnight.Width)
            {
                _knight.changeTexture(true);
                _sceneManager.GetCurrentScene().RemoveObject(this);
            }
        }
    }
}
