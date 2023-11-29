using J3P2_Monogame_Project.monoPong.Willemijn;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace J3P2_Monogame_Project.Framework
{
    public class SceneManager
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        List<Scene> _scenes;
        Scene _currentScene;
        Game1 _game;
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
            switch(sceneNumber)
            {
                case 0:
                    _currentScene.ExitScene();
                    _currentScene = _scenes[0];
                    break;
                case 1:
                    _currentScene.ExitScene();
                    _currentScene = _scenes[1];
                    break;
                case 2:
                    _currentScene.ExitScene();
                    _currentScene = _scenes[2];
                    break;
                case 3:
                    _currentScene.ExitScene();
                    _currentScene = _scenes[3];
                    break;
                case 4:
                    _currentScene.ExitScene();
                    _currentScene = _scenes[4];
                    break;
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
