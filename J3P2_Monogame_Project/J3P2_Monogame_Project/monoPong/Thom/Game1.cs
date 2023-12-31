﻿using J3P2_Monogame_Project.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace J3P2_Monogame_Project.monoPong.Thom
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Ball _ball;
        SpriteFont _font;

        private Wall _wall;
        Paddle testPaddle;
        Paddle testPaddle2;
        Paddle testPaddle3;
        Paddle testPaddle4;
        public List<GameObject> _objects = new List<GameObject>();
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _ball = new Ball(new Vector2(100, 100), 1, Content.Load<Texture2D>("BallTexture"), 120.0f, GraphicsDevice);
            testPaddle = new Paddle(new Vector2(50, 50), 0.5f, Content.Load<Texture2D>("Paddle"), 0, _ball, _font);
            testPaddle2 = new Paddle(new Vector2(750, 50), 0.5f, Content.Load<Texture2D>("Paddle"), 1, _ball, _font);
            testPaddle3 = new Paddle(new Vector2(450, 50), 0.5f, Content.Load<Texture2D>("PaddleHorizontal"), 2, _ball, _font);
            testPaddle4 = new Paddle(new Vector2(450, 450), 0.5f, Content.Load<Texture2D>("PaddleHorizontal"), 3, _ball, _font);
            _font = Content.Load<SpriteFont>("spritefont");
            _wall = new Wall(GraphicsDevice, _ball, testPaddle, this);

            //Objects
            _objects.Add(_ball);
            _objects.Add(testPaddle);
            _objects.Add(testPaddle2);
            _objects.Add(testPaddle3);
            _objects.Add(testPaddle4);

            for (int i = 0; i < _objects.Count; i++)
            {
                _objects[i].Start();
            }

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            for (int i = 0; i < _objects.Count; i++)
            {
                _objects[i].Update(gameTime);
            }
            _wall.Update();
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            for (int i = 0; i < _objects.Count; i++)
            {
                _objects[i].Draw(_spriteBatch);

            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}