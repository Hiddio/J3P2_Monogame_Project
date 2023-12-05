using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace J3P2_Monogame_Project.Framework
{
    public class Scene
    {
        protected SpriteBatch _spriteBatch;
        protected GraphicsDeviceManager _graphics;
        protected List<GameObject> _gameObjects = new List<GameObject>();
        public Scene(SpriteBatch pSpriteBatch, GraphicsDeviceManager pGraphics)
        {
            _spriteBatch = pSpriteBatch;
            _graphics = pGraphics;
        }
        public virtual void LoadContent(SceneManager sceneManager)
        {
            for (int i = 0; i < _gameObjects.Count; i++)
            {
                _gameObjects[i].Start();
            }
        }
        public virtual void Update(GameTime gameTime)
        {
            for (int i = 0; i < _gameObjects.Count; i++)
            {
                _gameObjects[i].Update(gameTime);
            }
        }

        public virtual void Draw()
        {
            for (int i = 0; i < _gameObjects.Count; i++)
            {
                _gameObjects[i].Draw(_spriteBatch);
            }
        }


    }
}
