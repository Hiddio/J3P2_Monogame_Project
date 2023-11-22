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
    public class SceneMenu : Scene
    {

        public SceneMenu(SpriteBatch spriteBatch, Game1 game, GraphicsDeviceManager graphics) : base(spriteBatch, game, graphics)
        {
            
        }

        public override void LoadObject(SceneManager sceneManager)
        {
            Texture2D textureQuitButton = _game.Content.Load<Texture2D>("Quit Button");
            Texture2D texturePlayButton = _game.Content.Load<Texture2D>("Play Button");
            PlayButton _playButton = new PlayButton(sceneManager, new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2, (_graphics.GraphicsDevice.Viewport.Height / 2) - 50), _graphics, texturePlayButton);
            QuitButton _quitButton = new QuitButton(sceneManager, new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2, (_graphics.GraphicsDevice.Viewport.Height / 2) + 50), _graphics, textureQuitButton);

            _gameObjects.Add(_playButton);
            _gameObjects.Add(_quitButton);
            base.LoadObject(sceneManager);
        }
    }
}
