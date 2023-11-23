using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace J3P2_Monogame_Project.Willemijn.Assignment3
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        public List<Scene> _scenes = new List<Scene>();
        public int currentScene = 0;

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

            SceneMenu sceneMenu = new SceneMenu(_spriteBatch, this, _graphics);
            SceneWon sceneWon = new SceneWon(_spriteBatch, this, _graphics);
            SceneLevel1 sceneLevel1 = new SceneLevel1(_spriteBatch, this, _graphics);
            SceneLevel2 sceneLevel2 = new SceneLevel2(_spriteBatch, this, _graphics);
            SceneLost sceneLost = new SceneLost(_spriteBatch, this, _graphics);

            _scenes.Add(sceneMenu);
            _scenes.Add(sceneLevel1);
            _scenes.Add(sceneLevel2);
            _scenes.Add(sceneLost);
            _scenes.Add(sceneWon);

            SceneManager sceneManager = new SceneManager(_scenes, this, _graphics);

            for (int i = 0; i < _scenes.Count; i++)
            {
                _scenes[i].LoadObject(sceneManager);

            }

        }




        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            _scenes[currentScene].Update(gameTime);
            
            
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }



        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _scenes[currentScene].Draw();
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }



    }
}