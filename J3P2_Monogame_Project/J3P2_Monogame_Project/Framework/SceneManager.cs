using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace J3P2_Monogame_Project.Framework
{
    public class SceneManager
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        enum GameScene
        {
            MainMenu,
            Level1,
            Level2,
        }
        GameScene _currentScene;
        public SceneManager(GraphicsDeviceManager pGraphics, SpriteBatch pSpriteBatch)
        {
            _graphics = pGraphics;
            _spriteBatch = pSpriteBatch;
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
                    _currentScene = (GameScene)0;
                    break;
                case 1:
                    _currentScene = (GameScene)1;
                    break;
                case 2:
                    _currentScene = (GameScene)2;
                    break;
            }
        }

    }
}
