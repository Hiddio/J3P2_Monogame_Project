using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using J3P2_Monogame_Project.monoPong.Willemijn;
using J3P2_Monogame_Project.Framework;

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
        public GameScene(SpriteBatch pSpriteBatch, Game1 pGame, GraphicsDeviceManager pGraphics, GraphicsDevice pDevice) : base(pSpriteBatch, pGraphics)
        {
            _game = pGame;
            _device = pDevice;
        }
        public override void LoadContent(SceneManager sceneManager, GraphicsDeviceManager pGraphics)
        {
            _backGround = new GameObject(new Vector2(pGraphics.PreferredBackBufferWidth / 2, pGraphics.PreferredBackBufferHeight / 2), 1f, _game.Content.Load<Texture2D>("BackGround"));
            _ball = new Ball(new Vector2(100, 100), 1.8f, _game.Content.Load<Texture2D>("BallTexture"), 120.0f, _device);
            testPaddle = new Paddle(new Vector2(pGraphics.PreferredBackBufferWidth / 2, pGraphics.PreferredBackBufferHeight / 2), 1.8f, _game.Content.Load<Texture2D>("Paddle"), 0, _ball);
            testPaddle2 = new Paddle(new Vector2(pGraphics.PreferredBackBufferWidth / 2, pGraphics.PreferredBackBufferHeight / 2), 1.8f, _game.Content.Load<Texture2D>("Paddle"), 1, _ball);
            testPaddle3 = new Paddle(new Vector2(pGraphics.PreferredBackBufferWidth / 2, pGraphics.PreferredBackBufferHeight / 2), 1.8f, _game.Content.Load<Texture2D>("PaddleHorizontal"), 2, _ball);
            testPaddle4 = new Paddle(new Vector2(pGraphics.PreferredBackBufferWidth / 2, pGraphics.PreferredBackBufferHeight / 2), 1.8f, _game.Content.Load<Texture2D>("PaddleHorizontal"), 3, _ball);

            _gameObjects.Add(_backGround);
            _gameObjects.Add(_ball);
            _gameObjects.Add(testPaddle);
            _gameObjects.Add(testPaddle2);
            _gameObjects.Add(testPaddle3);
            _gameObjects.Add(testPaddle4);
            base.LoadContent(sceneManager, pGraphics);
        }
        public override void Update(GameTime gameTime)
        {
            if (_ball._position.X >= (testPaddle._position.X - 10))
            {
                _gameObjects.Remove(testPaddle);
            }
        }
    }
}
