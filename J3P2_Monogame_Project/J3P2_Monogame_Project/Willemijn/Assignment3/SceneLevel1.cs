using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P2_Monogame_Project.Willemijn.Assignment3
{
    public class SceneLevel1 : Scene
    {

        public int numberFlags = 3;
        public List<Flag> _flags = new List<Flag>();

        public SceneLevel1(SpriteBatch spriteBatch, Game1 game, GraphicsDeviceManager graphics) : base(spriteBatch, game, graphics)
        {
        }

        public override void LoadObject(SceneManager sceneManager)
        {
            _knight = sceneManager._knight;
            Texture2D textureMenuButton = _game.Content.Load<Texture2D>("Menu Button");
            Texture2D textureShield = _game.Content.Load<Texture2D>("Shield");
            Texture2D textureGate = _game.Content.Load<Texture2D>("Gate");
            Texture2D textureEnemy = _game.Content.Load<Texture2D>("Enemy");
            Texture2D textureFlag = _game.Content.Load<Texture2D>("Flag");
            MenuButton _menuButton = new MenuButton(sceneManager, new Vector2(_graphics.GraphicsDevice.Viewport.Width - 100, 50), _graphics, textureMenuButton);
            Shield _shield = new Shield(sceneManager, new Vector2(100, 100), _graphics, textureShield, _knight);
            Gate _gate = new Gate(sceneManager, new Vector2(500, 200), _graphics, textureGate, _knight, 2);
            for (int i = 0; i < numberFlags; i++)
            {
                Random rnd = new Random();
                float x = rnd.Next(20, _graphics.GraphicsDevice.Viewport.Width - 20);
                float y = rnd.Next(20, _graphics.GraphicsDevice.Viewport.Height - 20);
                _flags.Add(new Flag(sceneManager, new Vector2(x, y), _graphics, textureFlag));
                _gameObjects.Add(_flags[i]);
            }
            Enemy _enemy = new Enemy(20, sceneManager, new Vector2(100, 400), _graphics, textureEnemy, _knight, _flags);

            _gameObjects.Add(_menuButton);
            _gameObjects.Add(_shield);
            _gameObjects.Add(_gate);
            _gameObjects.Add(_knight);
            _gameObjects.Add(_enemy);
            base.LoadObject(sceneManager);
        }

    }
}
