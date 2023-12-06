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

        public override void LoadContent(SceneManager sceneManager, GraphicsDeviceManager pGraphics)
        {

            Texture2D textureButtonPlay = _game.Content.Load<Texture2D>("ButtonTexturePlay");
            PlayButton _playButton = new PlayButton(new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 - (textureButtonPlay.Width / 2), (_graphics.GraphicsDevice.Viewport.Height / 2) + (textureButtonPlay.Height / 4) - 150), 1.8f, textureButtonPlay, sceneManager);
            Texture2D textureButtonQuit = _game.Content.Load<Texture2D>("ButtonTextureQuit");
            QuitButton _quitButton = new QuitButton(new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 - (textureButtonQuit.Width / 2), (_graphics.GraphicsDevice.Viewport.Height / 2) + (textureButtonQuit.Height / 4) + 150), 1.8f, textureButtonQuit, sceneManager);

            _gameObjects.Add(_playButton);
            _gameObjects.Add(_quitButton);
            base.LoadContent(sceneManager, pGraphics);
        }
    }
}
