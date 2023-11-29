using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using J3P2_Monogame_Project.Framework;

namespace J3P2_Monogame_Project.monoPong.Willemijn
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public List<Scene> _scenes = new List<Scene>();
        private SceneManager _sceneManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //_graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //_graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            MainMenu sceneMenu = new MainMenu(_spriteBatch, this, _graphics);
            PopupExplanation sceneExplanation = new PopupExplanation(_spriteBatch, this, _graphics);
            PopupGoal sceneGoal = new PopupGoal(_spriteBatch, this, _graphics);
            PopupMovement sceneMovement = new PopupMovement(_spriteBatch, this, _graphics);

            _scenes.Add(sceneMenu);
            _scenes.Add(sceneExplanation);
            _scenes.Add(sceneGoal);
            _scenes.Add(sceneMovement);

            _sceneManager = new SceneManager(_graphics, _spriteBatch, this, _scenes);

            for (int i = 0; i < _scenes.Count; i++)
            {
                _scenes[i].LoadContent(_sceneManager);

            }
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _scenes[_sceneManager.GetCurrentSceneInt()].Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            _scenes[_sceneManager.GetCurrentSceneInt()].Draw();
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}