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
        private List<GameObject> _objects = new List<GameObject>();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            for (int i = 0; i < _objects.Count; i++)
            {
                _objects[i].Start();
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _ball = new Ball(new Vector2(100, 100), 10, GraphicsDevice, new Rectangle(0,0,0,0), 150.0f);

            //Objects
            _objects.Add(_ball);
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
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            for (int i = 0; i < _objects.Count; i++)
            {
                _objects[i].DrawRectangle(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}