using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using J3P2_Monogame_Project.Framework;
using J3P2_Monogame_Project.monoPong.Willemijn;

namespace J3P2_Monogame_Project.monoPong
{
    class MainMenu : Scene
    {
        Game1 _game;
        public MainMenu(SpriteBatch pSpriteBatch, Game1 game, GraphicsDeviceManager pGraphics) : base(pSpriteBatch, pGraphics)
        {
            _game = game;
        }

        public override void LoadContent(SceneManager sceneManager)
        {
            
            Texture2D textureButton = _game.Content.Load<Texture2D>("ButtonTexture");
            PlayButton _playButton = new PlayButton(new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 + (textureButton.Width / 4), (_graphics.GraphicsDevice.Viewport.Height / 2) + (textureButton.Height / 4) - 50), .5f, textureButton, sceneManager);
            QuitButton _quitButton = new QuitButton(new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 + (textureButton.Width / 4), (_graphics.GraphicsDevice.Viewport.Height / 2) + (textureButton.Height / 4) + 50), .5f, textureButton, sceneManager);

            _gameObjects.Add(_playButton);
            _gameObjects.Add(_quitButton);
            base.LoadContent(sceneManager);
        }
    }
}
