using J3P2_Monogame_Project.monoPong.Willemijn;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace J3P2_Monogame_Project.Framework
{
    public class SceneManager
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public List<Scene> _scenes;
        private Scene _currentScene;
        private Game1 _game;
        private bool _firstTime = true;
        public SceneManager(GraphicsDeviceManager pGraphics, SpriteBatch pSpriteBatch, Game1 pGame, List<Scene> pScenes )
        {
            _graphics = pGraphics;
            _spriteBatch = pSpriteBatch;
            _game = pGame;
            _scenes = pScenes;
            _currentScene = _scenes[0];
        }

        public void Update(GameTime gameTime)
        {
          
        }

        public void Draw(GameTime gameTime)
        {

        }
        public void ChangeScene(int sceneNumber)
        {
            if (sceneNumber <= _scenes.Count - 1)
            {
                if (sceneNumber == 1) 
                {
                    if (_firstTime)
                    {
                        _firstTime = false;
                        _currentScene = _scenes[sceneNumber];
                    }
                    else
                    {
                        sceneNumber++;
                    }
                }
               _currentScene = _scenes[sceneNumber];
               
            }
            
        }
        public void CloseGame()
        {
            _game.Exit();
        }

        public int GetCurrentSceneInt()
        {
            return _scenes.IndexOf(_currentScene);
        }
    }
}
