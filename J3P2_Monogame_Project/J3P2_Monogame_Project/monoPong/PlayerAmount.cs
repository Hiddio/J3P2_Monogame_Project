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
            Texture2D textureButtonTwo = _game.Content.Load<Texture2D>("ButtonTextureTwo");
            Texture2D textureButtonThree = _game.Content.Load<Texture2D>("ButtonTextureThree");
            Texture2D textureButtonFour = _game.Content.Load<Texture2D>("ButtonTextureFour");
            _textFont = _game.Content.Load<SpriteFont>("SpriteFont");
            TwoPlayerButton _twoPlayerButton = new TwoPlayerButton(new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 + (textureButtonTwo.Width / 4), (_graphics.GraphicsDevice.Viewport.Height / 2) + (textureButtonTwo.Height / 4) - 100), textureButtonTwo, sceneManager);
            ThreePlayerButton _threePlayerButton = new ThreePlayerButton(new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 + (textureButtonThree.Width / 4), (_graphics.GraphicsDevice.Viewport.Height / 2) + (textureButtonThree.Height / 4)), textureButtonThree, sceneManager);
            FourPlayerButton _fourPlayerButton = new FourPlayerButton(new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 + (textureButtonFour.Width / 4), (_graphics.GraphicsDevice.Viewport.Height / 2) + (textureButtonFour.Height / 4) + 100), textureButtonFour, sceneManager);

            _text1 = "Choose the amount of players:";
            
            _gameObjects.Add(_twoPlayerButton);
            _gameObjects.Add(_threePlayerButton);
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
