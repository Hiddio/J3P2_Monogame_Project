using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace J3P2_Monogame_Project.Framework
{
    internal class GameObject
    {
        protected Vector2 _position;
        protected Texture2D _texture;
        protected Vector2 _scale;
        GraphicsDevice _graphicsDevice;
        protected Rectangle? _hitbox;
        public Rectangle HitBox
        {
            // only has getter, it cannot be set to a value from anywhere
            get
            {
                // if the backing field (our _hitbox rectangle) is null, then we set it to a new Rectangle with the correct scale.
                _hitbox ??= new(0, 0, (int)(_texture.Width * _scale.X), (int)(_texture.Height * _scale.Y));
                // be cause the backingfield is nullable, we get the value cuz struct will be of type Nullable<Rectangle>
                Rectangle rect = _hitbox.Value;
                // set the position of the hitbox according to the objects position
                rect.X = (int)_position.X - (_texture.Width / 2);
                rect.Y = (int)_position.Y - (_texture.Height / 2);
                // return the final hitbox
                return rect;
            }
        }
       /// <summary>
       /// This is for a sprite gameobject
       /// </summary>
       /// <param name="pPosition"></param>
       /// <param name="pScale"></param>
       /// <param name="pTexture"></param>
        public GameObject(Vector2 pPosition, Vector2 pScale, Texture2D pTexture)
        {
            _position = pPosition;
            _scale = pScale;
            _texture = pTexture;
        }
        /// <summary>
        /// This is for a no-sprite gameobject
        /// </summary>
        /// <param name="pPosition"></param>
        /// <param name="pScale"></param>
        /// <param name="pGraphicsDevice"></param>
        public GameObject(Vector2 pPosition, Vector2 pScale, GraphicsDevice pGraphicsDevice, Rectangle pRectangle)
        {
            _position = pPosition;
            _scale = pScale;
            _graphicsDevice = pGraphicsDevice;
            _hitbox = pRectangle;
        }
        public virtual void Update(GameTime pGameTime)
        {   
        } 
        public virtual void Start()
        {
        }
        public virtual void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(_texture, new Vector2(_position.X - (_texture.Width / 2), _position.Y - (_texture.Height / 2)), null, Color.White, 0, Vector2.Zero, _scale, SpriteEffects.None, 0);
        }
        /// <summary>
        /// Draw the rectangle.
        /// </summary>
        /// <param name="pSpriteBatch"></param>
        public virtual void DrawRectangle(SpriteBatch pSpriteBatch)
        {
            // make a new Texture 1x1
            _texture = new Texture2D(_graphicsDevice, 1, 1);
            // Set the colour of the texture to red
            _texture.SetData(new Color[] {Color.Red});
            // draw the rectangle
            pSpriteBatch.Draw(_texture, new Rectangle((int)_position.X, (int)_position.Y, 1 * (int)_scale, 1 * (int)_scale), Color.White);
        }
    }
}
