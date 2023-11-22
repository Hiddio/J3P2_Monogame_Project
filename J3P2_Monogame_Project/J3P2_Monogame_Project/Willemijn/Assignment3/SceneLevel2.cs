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
    public class SceneLevel2 : Scene
    {
        public int numberFlags = 3;
        public List<Flag> _flags = new List<Flag>();

        public SceneLevel2(SpriteBatch spriteBatch, Game1 game, GraphicsDeviceManager graphics) : base(spriteBatch, game, graphics)
        {
        }

        public override void LoadObject(SceneManager sceneManager)
        {
            _knight = sceneManager._knight;
            Texture2D textureMenuButton = _game.Content.Load<Texture2D>("Menu Button");
            Texture2D textureGate = _game.Content.Load<Texture2D>("Gate");
            Texture2D textureEnemy = _game.Content.Load<Texture2D>("Enemy");
            Texture2D textureFlag = _game.Content.Load<Texture2D>("Flag");
            Texture2D textureWeapon = _game.Content.Load<Texture2D>("Weapon");

            Gate _gate = new Gate(sceneManager, new Vector2(500, 400), _graphics, textureGate, _knight, 1);
            MenuButton _menuButton = new MenuButton(sceneManager, new Vector2(_graphics.GraphicsDevice.Viewport.Width - 100, 50), _graphics, textureMenuButton);
            Sword _sword = new Sword(sceneManager, new Vector2(200, 200), _graphics, textureWeapon, _knight);

            for (int i = 0; i < numberFlags; i++)
            {
                Random rnd = new Random();
                float x = rnd.Next(20, _graphics.GraphicsDevice.Viewport.Width - 20);
                float y = rnd.Next(20, _graphics.GraphicsDevice.Viewport.Height - 20);
                _flags.Add(new Flag(sceneManager, new Vector2(x, y), _graphics, textureFlag));
                _gameObjects.Add(_flags[i]);
            }

            Enemy _enemy1 = new Enemy(0, sceneManager, new Vector2(100, 200), _graphics, textureEnemy, _knight, _flags);
            Enemy _enemy2 = new Enemy(50, sceneManager, new Vector2(500, 300), _graphics, textureEnemy, _knight, _flags);


            _gameObjects.Add(_menuButton);
            _gameObjects.Add(_sword);
            _gameObjects.Add(_gate);
            _gameObjects.Add(_enemy1);
            _gameObjects.Add(_enemy2);
            _gameObjects.Add(_knight);
            base.LoadObject(sceneManager);
        }
        
    }
}
