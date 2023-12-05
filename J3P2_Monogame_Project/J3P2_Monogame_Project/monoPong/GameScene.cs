using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using J3P2_Monogame_Project.monoPong.Willemijn;
using J3P2_Monogame_Project.Framework;
using System.Reflection.Metadata;

namespace J3P2_Monogame_Project.monoPong
{
    class GameScene : Scene
    {
        private Game1 _game;
        private GraphicsDevice _device;
        private Ball _ball;
        private Paddle testPaddle;
        private Paddle testPaddle2;
        private Paddle testPaddle3;
        private Paddle testPaddle4;
        public GameScene(SpriteBatch pSpriteBatch, Game1 pGame, GraphicsDeviceManager pGraphics, GraphicsDevice pDevice) : base(pSpriteBatch, pGraphics)
        {
            _game = pGame;
            _device = pDevice;
        }
        public override void LoadContent(SceneManager sceneManager)
        {

            _ball = new Ball(new Vector2(100, 100), _game.Content.Load<Texture2D>("BallTexture"), 120.0f, _device);
            testPaddle = new Paddle(new Vector2(50, 50), _game.Content.Load<Texture2D>("Paddle"), 0, _ball);
            testPaddle2 = new Paddle(new Vector2(750, 50), _game.Content.Load<Texture2D>("Paddle"), 1, _ball);
            testPaddle3 = new Paddle(new Vector2(450, 50), _game.Content.Load<Texture2D>("PaddleHorizontal"), 2, _ball);
            testPaddle4 = new Paddle(new Vector2(450, 450), _game.Content.Load<Texture2D>("PaddleHorizontal"), 3, _ball);

            _gameObjects.Add(_ball);
            _gameObjects.Add(testPaddle);
            _gameObjects.Add(testPaddle2);
            _gameObjects.Add(testPaddle3);
            _gameObjects.Add(testPaddle4);
            base.LoadContent(sceneManager);
        }
    }
}
