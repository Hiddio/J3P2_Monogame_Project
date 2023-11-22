using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3P2_Monogame_Project.Willemijn.Assignment3
{
    public class SceneManager
    {
        public List<Scene> _scenes;
        private Game1 _game;
        private Scene _currentScene;
        public Knight _knight;
        public int _won = 2;

        public SceneManager(List<Scene> scenes, Game1 game, GraphicsDeviceManager graphics)
        {
            _scenes = scenes;
            _game = game;
            _currentScene = _scenes[0];
            NewKnight(graphics);
        }

        public void ChangeScene(int newScene)
        {
            _game.currentScene = newScene;
            _currentScene = _scenes[newScene];
            
        }

        public void CloseGame()
        {
            _game.Exit();
        }

        public Scene GetCurrentScene()
        {
            return _currentScene;
        }

        public int GetCurrentSceneInt()
        {
            return _scenes.IndexOf(_currentScene);
        }

        public virtual void NewKnight(GraphicsDeviceManager graphics)
        {
            _knight = new Knight(this, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2), graphics);
        }
    }
}
