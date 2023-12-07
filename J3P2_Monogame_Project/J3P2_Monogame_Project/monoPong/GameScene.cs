using J3P2_Monogame_Project.Framework;
using J3P2_Monogame_Project.monoPong.Willemijn;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace J3P2_Monogame_Project.monoPong
{
    class GameScene : Scene
    {
        private Game1 _game;
        private GraphicsDevice _device;
        private GameObject _backGround;
        private Ball _ball;
        private Paddle testPaddle;
        private Paddle testPaddle2;
        private Paddle testPaddle3;
        private Paddle testPaddle4;

        private List<Paddle> _paddleList = new List<Paddle>();

        private SpriteFont _font;
        public GameScene(SpriteBatch pSpriteBatch, Game1 pGame, GraphicsDeviceManager pGraphics, GraphicsDevice pDevice) : base(pSpriteBatch, pGraphics)
        {
            _game = pGame;
            _device = pDevice;
            _font = _game.Content.Load<SpriteFont>("SpriteFont");
        }
        public override void LoadContent(SceneManager sceneManager, GraphicsDeviceManager pGraphics)
        {
            _backGround = new GameObject(new Vector2(pGraphics.PreferredBackBufferWidth / 2, pGraphics.PreferredBackBufferHeight / 2), 1f, _game.Content.Load<Texture2D>("BackGround"));
            _ball = new Ball(new Vector2(100, 100), 1.8f, _game.Content.Load<Texture2D>("BallTexture"), 250.0f, _device);
            testPaddle = new Paddle(new Vector2(pGraphics.PreferredBackBufferWidth / 2 - 530, pGraphics.PreferredBackBufferHeight / 2), 1.8f, _game.Content.Load<Texture2D>("Paddle"), 0, _ball, _font);
            testPaddle2 = new Paddle(new Vector2(pGraphics.PreferredBackBufferWidth / 2 + 530, pGraphics.PreferredBackBufferHeight / 2), 1.8f, _game.Content.Load<Texture2D>("Paddle"), 1, _ball, _font);
            testPaddle3 = new Paddle(new Vector2(pGraphics.PreferredBackBufferWidth / 2, pGraphics.PreferredBackBufferHeight / 2 + 500), 1.8f, _game.Content.Load<Texture2D>("PaddleHorizontal"), 2, _ball, _font);
            testPaddle4 = new Paddle(new Vector2(pGraphics.PreferredBackBufferWidth / 2, pGraphics.PreferredBackBufferHeight / 2 - 500), 1.8f, _game.Content.Load<Texture2D>("PaddleHorizontal"), 3, _ball, _font);


            _gameObjects.Add(_backGround);
            _gameObjects.Add(_ball);
            _gameObjects.Add(testPaddle);
            _gameObjects.Add(testPaddle2);
            _gameObjects.Add(testPaddle3);
            _gameObjects.Add(testPaddle4);

            _paddleList.Add(testPaddle);
            _paddleList.Add(testPaddle2);
            _paddleList.Add(testPaddle3);
            _paddleList.Add(testPaddle4);

            base.LoadContent(sceneManager, pGraphics);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (_ball._position.X <= (testPaddle._position.X - 10) && testPaddle.isActive != false)
            {
                testPaddle.paddleLives--;
                _ball.SpawnBallInMiddle();
            }
            if (_ball._position.X >= (testPaddle2._position.X - 10) && testPaddle2.isActive != false)
            {
                testPaddle2.paddleLives--;
                _ball.SpawnBallInMiddle();
            }
            if (_ball._position.Y >= (testPaddle3._position.Y - 10) && testPaddle3.isActive != false)
            {
                testPaddle3.paddleLives--;
                _ball.SpawnBallInMiddle();
            }
            if (_ball._position.Y <= (testPaddle4._position.Y - 10) && testPaddle4.isActive != false)
            {
                testPaddle4.paddleLives--;
                _ball.SpawnBallInMiddle();
            }
           for (int i = 0; i < _paddleList.Count; i++)
            {
                if (_paddleList[i].paddleLives == 0)
                {
                    _paddleList[i].isActive = false;
                    _gameObjects.Remove(_paddleList[i]);
                }
            }
        }
    }
}
