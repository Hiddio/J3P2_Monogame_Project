using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.DirectWrite;
using System;
using System.Collections.Generic;
using J3P2_Monogame_Project.Framework;

namespace J3P2_Monogame_Project.monoPong.Willemijn
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Vector2 _scale;
        private List<Scene> _scenes = new List<Scene>();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _scale.X = (float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / (float)_graphics.PreferredBackBufferWidth;
            _scale.Y = (float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / (float)_graphics.PreferredBackBufferHeight;
            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            MainMenu sceneMenu = new MainMenu(_spriteBatch, _graphics, _scale);

            _scenes.Add(sceneMenu);

            SceneManager sceneManager = new SceneManager(_graphics, _spriteBatch, this);

            for (int i = 0; i < _scenes.Count; i++)
            {
                _scenes[i].LoadContent(sceneManager);

            }
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}