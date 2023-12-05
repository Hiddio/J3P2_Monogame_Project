﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace J3P2_Monogame_Project.Framework
{
    public class GameObject
    {
        public Vector2 _position;
        protected Texture2D _texture;
        protected float _scale;
        protected GraphicsDevice _graphicsDevice;
        protected Rectangle? _hitbox;


        protected Texture2D debugTexture;


       /// <summary>
       /// This is for a sprite gameobject
       /// </summary>
       /// <param name="pPosition"></param>
       /// <param name="pScale"></param>
       /// <param name="pTexture"></param>
        public GameObject(Vector2 pPosition, Texture2D pTexture)
        {
            _position = pPosition;
            _scale = 1.8f;
            _texture = pTexture;
        }
        
        
        public virtual Rectangle HitBox
        {
            // only has getter, it cannot be set to a value from anywhere
            get
            {
                // if the backing field (our _hitbox rectangle) is null, then we set it to a new Rectangle with the correct scale.
                _hitbox ??= new(0, 0, (int)(_texture.Width * _scale), (int)(_texture.Height * _scale));
                // be cause the backingfield is nullable, we get the value cuz struct will be of type Nullable<Rectangle>
                Rectangle rect = _hitbox.Value;
                // set the position of the hitbox according to the objects position
                rect.X = (int)_position.X - (_texture.Width / 2);
                rect.Y = (int)_position.Y - (_texture.Height / 2);
                // return the final hitbox
                return rect;
            }
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

            // draw the rectangle
            pSpriteBatch.Draw(debugTexture, new Rectangle((int)_position.X, (int)_position.Y, 1 * (int)_scale, 1 * (int)_scale), Color.White);
        }
        public virtual void DrawString(SpriteBatch pSpriteBatch)
        {

        }
    }
}
