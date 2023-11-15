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
        // this is the constructor of the GameObject class
        public GameObject(Vector2 pos, float scale, Texture2D texture)
        {
            Position = pos;
            _scale = scale;
            _texture = texture;
        }
        public void Update()
        {
            
        } 
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Vector2(Position.X - (_texture.Width / 2), Position.Y - (_texture.Height / 2)), null, Color.White, 0, Vector2.Zero, _scale, SpriteEffects.None, 0);
        }
    }
}
