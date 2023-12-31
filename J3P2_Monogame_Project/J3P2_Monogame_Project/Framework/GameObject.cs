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
                rect.X = (int)_position.X - (_texture.Width * (int)_scale / 2);
                rect.Y = (int)_position.Y - (_texture.Height * (int)_scale / 2);
                // return the final hitbox
                return rect;
            }
        }
        protected Texture2D debugTexture;


       /// <summary>
       /// This is for a sprite gameobject
       /// </summary>
       /// <param name="pPosition"></param>
       /// <param name="pScale"></param>
       /// <param name="pTexture"></param>
        public GameObject(Vector2 pPosition, float pScale ,Texture2D pTexture)
        {
            _position = pPosition;
            _scale = pScale;
            _texture = pTexture;
        }
        
        public virtual void Update(GameTime pGameTime)
        {   

        } 
        public virtual void Start()
        {

        }
        public virtual void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(_texture, new Vector2(_position.X - (_texture.Width * _scale / 2), _position.Y - (_texture.Height * _scale / 2)), null, Color.White, 0, Vector2.Zero, _scale, SpriteEffects.None, 0);
        }
        
        public virtual void DrawString(SpriteBatch pSpriteBatch)
        {

        }
    }
}
