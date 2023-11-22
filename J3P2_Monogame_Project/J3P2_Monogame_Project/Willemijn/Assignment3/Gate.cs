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
    public class Gate : GameObject
    {
        private Knight _knight;
        private int _destinationScene;
        public Gate(SceneManager sceneManager, Vector2 position, GraphicsDeviceManager graphics, Texture2D texture, Knight knight, int destinationScene) : base(sceneManager, position, graphics, texture)
        {
            _knight = knight;
            _destinationScene = destinationScene;
        }

        public override void Update(GameTime gameTime)
        {
            float distancePlayer = Vector2.Distance(_position, _knight._position);
            if (distancePlayer < _knight._textureKnight.Width)
            {
                _sceneManager.ChangeScene(_destinationScene);
                _knight.newPosition();
            }
        }
    }
}