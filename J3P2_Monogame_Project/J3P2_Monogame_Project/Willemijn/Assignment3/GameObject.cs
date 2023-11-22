using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P2_Monogame_Project.Willemijn.Assignment3
{
    public class GameObject
    {
        public Vector2 _position;
        protected Color color = Color.White;
        public Texture2D _texture;
        protected GraphicsDeviceManager _graphics;
        public Vector2 _center;
        public SceneManager _sceneManager;

        public GameObject(SceneManager sceneManager, Vector2 position, GraphicsDeviceManager graphics)
        {
            _position = position;
            _graphics = graphics;
            _sceneManager = sceneManager;
        }

        public GameObject(SceneManager sceneManager, Vector2 position, GraphicsDeviceManager graphics, Texture2D texture)
        {
            _position = position;
            _graphics = graphics;
            _texture = texture;
            _sceneManager = sceneManager;
            _center = new Vector2(_texture.Width * 0.5f, _texture.Height * 0.5f);

        }

        public virtual void LoadObject(ContentManager content)
        {

        }


        public virtual void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, color, 0, _center, new Vector2(1, 1), SpriteEffects.None, 0);


        }
    }
}
