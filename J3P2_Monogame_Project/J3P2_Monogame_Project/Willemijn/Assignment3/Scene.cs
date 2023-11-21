using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P2_Monogame_Project.Willemijn.Assignment3
{
    public class Scene
    {
        public List<GameObject> _gameObjects = new List<GameObject>();
        public SpriteBatch _spriteBatch;
        public  Game1 _game;
        public Scene _currentScene;
        public GraphicsDeviceManager _graphics;
        public SceneManager _sceneManager;
        public Knight _knight;
        public List<Heart> _hearts = new List<Heart>();
        public Scene(SpriteBatch spriteBatch, Game1 game, GraphicsDeviceManager graphics)
        {
            _game = game;
            _spriteBatch = spriteBatch;
            _graphics = graphics;
        }

        public virtual void LoadObject(SceneManager sceneManager)
        {
            _sceneManager = sceneManager;
            for (int i = 0; i < _gameObjects.Count; i++)
            {                
                _gameObjects[i].LoadObject(_game.Content);
            }
            for (int i = 0; i < _sceneManager._knight._hearts.Count; i++)
            {
                _sceneManager._knight._hearts[i].LoadObject(_game.Content);
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            if (_sceneManager.GetCurrentSceneInt() == 1 || _sceneManager.GetCurrentSceneInt() == 2)
            {
                _hearts = _knight._hearts;
                for (int i = 0; i < _hearts.Count; i++)
                {
                    _hearts[i].Update(gameTime);
                }
            }
            for (int i = 0; i < _gameObjects.Count; i++)
            {
                _gameObjects[i].Update(gameTime);
            }
        }
        public virtual void Draw()
        {
            for (int i = 0; i < _hearts.Count; i++)
            {
                _hearts[i].Draw(_spriteBatch);
            }
            for (int i = 0; i < _gameObjects.Count; i++)
            {
                _gameObjects[i].Draw(_spriteBatch);
            }
        }

        public void RemoveObject(GameObject gameObject)
        {
            _gameObjects.Remove(gameObject);
        }
    }
}

