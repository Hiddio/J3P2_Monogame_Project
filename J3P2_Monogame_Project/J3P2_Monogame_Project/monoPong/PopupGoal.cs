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
    class PopupGoal : Scene
    {
        private Game1 _game;
        private SpriteFont _textFont;
        private string text1;
        private string text2;
        private string text3;
        private List<string> texts = new List<string>();
        public PopupGoal(SpriteBatch pSpriteBatch, Game1 game, GraphicsDeviceManager pGraphics) : base(pSpriteBatch, pGraphics)
        {
            _game = game;
        }

        public override void LoadContent(SceneManager sceneManager)
        {

            Texture2D textureButtonPlay = _game.Content.Load<Texture2D>("ButtonTexturePlay");
            _textFont = _game.Content.Load<SpriteFont>("SpriteFont");
            PlayButton _playButton = new PlayButton(new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 + (textureButtonPlay.Width / 4), (_graphics.GraphicsDevice.Viewport.Height / 2) + (textureButtonPlay.Height / 4) + 50), .5f, textureButtonPlay, sceneManager);
            text1 = "The goal of the game is to be the last one standing.";
            text2 = "That means that you need to defend your wall to";
            text3 = "have more health left than the other 3 players.";
            texts.Add(text1);
            texts.Add(text2);
            texts.Add(text3);
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