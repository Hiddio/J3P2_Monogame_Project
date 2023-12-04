using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using J3P2_Monogame_Project.Framework;
using J3P2_Monogame_Project.monoPong.Willemijn;

namespace J3P2_Monogame_Project.monoPong
{
    class PlayerAmount : Scene
    {
        Game1 _game;
        private string _text1;
        private SpriteFont _textFont;
        public PlayerAmount(SpriteBatch pSpriteBatch, Game1 pGame, GraphicsDeviceManager pGraphics) : base(pSpriteBatch, pGraphics)
        {
            _game = pGame;
        }
        public override void LoadContent(SceneManager sceneManager)
        {
            Texture2D textureButton = _game.Content.Load<Texture2D>("ButtonTexture");
            _textFont = _game.Content.Load<SpriteFont>("SpriteFont");
            TwoPlayerButton _twoPlayerButton = new TwoPlayerButton(new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 + (textureButton.Width / 4), (_graphics.GraphicsDevice.Viewport.Height / 2) + (textureButton.Height / 4) - 50), .5f, textureButton, sceneManager);
            FourPlayerButton _fourPlayerButton = new FourPlayerButton(new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 + (textureButton.Width / 4), (_graphics.GraphicsDevice.Viewport.Height / 2) + (textureButton.Height / 4) + 50), .5f, textureButton, sceneManager);

            _text1 = "Choose the amount of players:";
            
            _gameObjects.Add(_twoPlayerButton);
            _gameObjects.Add(_fourPlayerButton);
            base.LoadContent(sceneManager);
        }

        public override void Draw()
        {

            _spriteBatch.DrawString(_textFont, _text1, new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 - (_textFont.MeasureString(_text1).X / 2), _graphics.GraphicsDevice.Viewport.Height / 200 + 50), Color.White);

            base.Draw();
        }

    }
}
