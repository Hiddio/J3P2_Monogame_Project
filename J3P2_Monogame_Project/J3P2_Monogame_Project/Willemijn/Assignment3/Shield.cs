using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace J3P2_Monogame_Project.Willemijn.Assignment3
{
    public class Shield : GameObject
    {
        private Knight _knight;
        public Shield(SceneManager sceneManager, Vector2 position, GraphicsDeviceManager graphics, Texture2D texture, Knight knight) : base(sceneManager, position, graphics, texture)
        {
            _knight = knight;
        }

        public override void Update(GameTime gameTime)
        {

            float distancePlayer = Vector2.Distance(_position, _knight._position);

            if (distancePlayer < _knight._textureKnight.Width)
            {
                _knight.changeTexture(false);
                Scene _currentScene = _sceneManager.GetCurrentScene();
                _currentScene.RemoveObject(this);
            }
        }
    }
}
