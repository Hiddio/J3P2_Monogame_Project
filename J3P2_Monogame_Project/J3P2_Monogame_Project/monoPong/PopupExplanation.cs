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
    class PopupExplanation : Scene
    {
        private Game1 _game;
        private SpriteFont _textFont;
        private string text1;
        private string text2;
        private string text3;
        private string text4;
        private string text5;
        private List<string> texts = new List<string>();
        public PopupExplanation(SpriteBatch pSpriteBatch, Game1 game, GraphicsDeviceManager pGraphics) : base(pSpriteBatch, pGraphics)
        {
            _game = game;
        }

        public override void LoadContent(SceneManager sceneManager)
        {
            
            Texture2D textureButtonPlay = _game.Content.Load<Texture2D>("ButtonTexturePlay");
            _textFont = _game.Content.Load<SpriteFont>("SpriteFont");
            PlayButton _playButton = new PlayButton(new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 + (textureButtonPlay.Width / 4), (_graphics.GraphicsDevice.Viewport.Height / 2) + (textureButtonPlay.Height / 4) + 50), .5f, textureButtonPlay, sceneManager);
            text1 = "MonoPong is a two-dimensional table tennis game in which";
            text2 = "you move your paddle to defend your wall from the ball.";
            text3 = "If the ball hits the paddle it bounces back,";
            text4 = "but if it hits the wall, you lose health.";
            text5 = "Monopong is played with 4 players.";
            texts.Add(text1);
            texts.Add(text2);
            texts.Add(text3);
            texts.Add(text4);
            texts.Add(text5);
            
            _gameObjects.Add(_playButton);
            base.LoadContent(sceneManager);
        }

        public override void Draw()
        {
            for (int i = 0; i < texts.Count; i++)
            {
                _spriteBatch.DrawString(_textFont, texts[i], new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 - (_textFont.MeasureString(texts[i]).X / 2), _graphics.GraphicsDevice.Viewport.Height / 200 + (50 * i)), Color.White);
            }
            base.Draw();
        }
    }
}
