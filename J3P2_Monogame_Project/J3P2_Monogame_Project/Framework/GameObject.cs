using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace J3P2_Monogame_Project.Framework
{
    internal class GameObject
    {
        public Vector2 Position;
        protected Texture2D _texture;
        protected float _scale;
        GraphicsDevice _graphicsDevice;
        Rectangle? _hitbox;
        public Rectangle HitBox
        {
            // only has getter, it cannot be set to a value from anywhere
            get
            {
                // if the backing field is null, then we set it to a new Rectangle with the correct scale.
                _hitbox ??= new(0, 0, (int)(_texture.Width * _scale), (int)(_texture.Height * _scale));
                // be cause the backingfield is nullable, we get the value cuz struct will be of type Nullable<Rectangle>
                Rectangle rect = _hitbox.Value;
                // set the position of the hitbox according to the objects position
                rect.X = (int)Position.X - (_texture.Width / 2);
                rect.Y = (int)Position.Y - (_texture.Height / 2);
                // return the final hitbox
                return rect;
            }
        }
       /// <summary>
       /// This is for a sprite gameobject
       /// </summary>
       /// <param name="pos"></param>
       /// <param name="scale"></param>
       /// <param name="texture"></param>
        public GameObject(Vector2 pos, float scale, Texture2D texture)
        {
            Position = pos;
            _scale = scale;
            _texture = texture;
        }
        /// <summary>
        /// This is for a no-sprite gameobject
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="scale"></param>
        /// <param name="texture"></param>
        /// <param name="pGraphicsDevice"></param>
        public GameObject(Vector2 pos, float scale, GraphicsDevice pGraphicsDevice)
        {
            Position = pos;
            _scale = scale;
            _graphicsDevice = pGraphicsDevice;
        }
        public virtual void Update()
        {
            
        } 
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Vector2(Position.X - (_texture.Width / 2), Position.Y - (_texture.Height / 2)), null, Color.White, 0, Vector2.Zero, _scale, SpriteEffects.None, 0);
        }
        /// <summary>
        /// Draw the rectangle.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void DrawRectangle(SpriteBatch spriteBatch)
        {
            // make a new Texture 1x1
            _texture = new Texture2D(_graphicsDevice, 1, 1);
            // Set the colour of the texture to red
            _texture.SetData(new Color[] {Color.Red});
            // draw the rectangle
            spriteBatch.Draw(_texture, new Rectangle((int)Position.X, (int)Position.Y, 1 * (int)_scale, 1 * (int)_scale), Color.White);
        }
    }
}
