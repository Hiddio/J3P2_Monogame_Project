﻿using Microsoft.Xna.Framework;
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
    class PopupMovement : Scene
    {
        private Game1 _game;
        private SpriteFont _textFont;
        private string text1;
        private string text2;
        private string text3;
        private List<string> texts = new List<string>();
        public PopupMovement(SpriteBatch pSpriteBatch, Game1 pGame, GraphicsDeviceManager pGraphics) : base(pSpriteBatch, pGraphics)
        {
            _game = pGame;
        }

        public override void LoadContent(SceneManager pSceneManager, GraphicsDeviceManager pGraphics)
        {
            GameObject _alpacaArnoud = new GameObject(new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 + 200, _graphics.GraphicsDevice.Viewport.Height / 2 + 400), 1f, (_game.Content.Load<Texture2D>("MonoAlpaca")));
            Texture2D textureButtonPlay = _game.Content.Load<Texture2D>("ButtonTexturePlay");
            _textFont = _game.Content.Load<SpriteFont>("SpriteFont");
            
            PlayButton _playButton = new PlayButton(new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2 + (textureButtonPlay.Width / 4), (_graphics.GraphicsDevice.Viewport.Height / 2) + (textureButtonPlay.Height / 4) + 50), 1.8f, textureButtonPlay, pSceneManager);
            text1 = "The left paddle can be moved with W and S.";
            text2 = "The right paddle can be moved with the top and bottom arrows.";
            text3 = "The top and bottom paddles can be moved with the controllers.";
            texts.Add(text1);
            texts.Add(text2);
            texts.Add(text3);

            _gameObjects.Add(_alpacaArnoud);
            _gameObjects.Add(_playButton);
            base.LoadContent(pSceneManager, _graphics);
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
