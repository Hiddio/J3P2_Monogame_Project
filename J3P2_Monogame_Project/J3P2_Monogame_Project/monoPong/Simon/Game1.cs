using J3P2_Monogame_Project.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Security.AccessControl;

namespace J3P2_Monogame_Project.monoPong.Simon
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Paddle testPaddle;
        Paddle testPaddle2;
        Paddle testPaddle3;
        Paddle testPaddle4;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            testPaddle = new Paddle(new Vector2(50, 50), 0.5f, Content.Load<Texture2D>("Paddle"), 0);
            testPaddle2 = new Paddle(new Vector2(750, 50), 0.5f, Content.Load<Texture2D>("Paddle"), 1);
            testPaddle3 = new Paddle(new Vector2(450, 50), 0.5f, Content.Load<Texture2D>("PaddleHorizontal"), 2);
            testPaddle4 = new Paddle(new Vector2(450, 450), 0.5f, Content.Load<Texture2D>("PaddleHorizontal"), 3);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            Console.WriteLine(GamePad.GetState(PlayerIndex.One));
            Console.WriteLine(GamePad.GetState(PlayerIndex.Two));
            Console.WriteLine(GamePad.GetState(PlayerIndex.Three));
            Console.WriteLine(GamePad.GetState(PlayerIndex.Four));

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            testPaddle.Update(gameTime);
            testPaddle2.Update(gameTime);
            testPaddle3.Update(gameTime);
            testPaddle4.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            testPaddle.Draw(_spriteBatch);
            testPaddle2.Draw(_spriteBatch);
            testPaddle3.Draw(_spriteBatch);
            testPaddle4.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}