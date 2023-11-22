using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P2_Monogame_Project.Willemijn.Assignment3
{
    public class SceneWon : Scene
    {
        public SceneWon(SpriteBatch spriteBatch, Game1 game, GraphicsDeviceManager graphics) : base(spriteBatch, game, graphics)
        {
            
        }

        public override void LoadObject(SceneManager sceneManager)
        {
            Texture2D textureWon = _game.Content.Load<Texture2D>("You Won");
            Texture2D textureQuitButton = _game.Content.Load<Texture2D>("Quit Button");
            WonLost _won = new WonLost(sceneManager, new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2, 100), _graphics, textureWon);
            QuitButton _quitButton = new QuitButton(sceneManager, new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2, (_graphics.GraphicsDevice.Viewport.Height / 2) + 50), _graphics, textureQuitButton);

            _gameObjects.Add(_won);
            _gameObjects.Add(_quitButton);
            base.LoadObject(sceneManager);
        }
    }
}
