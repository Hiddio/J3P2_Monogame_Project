﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace J3P2_Monogame_Project.Framework
{
    class Button : GameObject
    {
        protected SpriteFont _textFont;
        protected MouseState _mouseState;
        protected Point _mousePosition;
        protected ButtonState lastMouseClick = Mouse.GetState().LeftButton;
        public int _playerAmount;
        protected Color _color;

        protected enum State
        {
            Normal, 
            Hovered,
            Pressed
        }
        protected State _currentState;
        public Button(Vector2 pPosition, float pScale, Texture2D pTexture, Color pColor) : base(pPosition, pScale, pTexture)
        {
            _color = pColor;
        }
        public override void Update(GameTime pGameTime)
        {
            _mouseState = Mouse.GetState();
            _mousePosition = new Point(_mouseState.X, _mouseState.Y);
            switch(_currentState)
            {
                case State.Normal:
                    NormalMode();
                    break;

                case State.Hovered:
                    HoverMode();
                    break;

                case State.Pressed:
                    PressedMode();
                    break;            
            }
            lastMouseClick = _mouseState.LeftButton;
        }
        protected virtual void NormalMode()
        {
            if (HitBox.Contains(_mousePosition))
            {
                _color = Color.LightGray;
                _currentState = State.Hovered;
            }
        }
        protected virtual void HoverMode()
        {
            if (!HitBox.Contains(_mousePosition))
            {
                _color = Color.White;
                _currentState = State.Normal;
            }
            if (_mouseState.LeftButton == ButtonState.Pressed & lastMouseClick == ButtonState.Released)
            {
                    _color = Color.DarkGray;
                    _currentState = State.Pressed;
            }
        }
        protected virtual void PressedMode()
        {
            if (_mouseState.LeftButton == ButtonState.Released & lastMouseClick == ButtonState.Pressed)
            {
                if (HitBox.Contains(_mousePosition))
                {
                    _color = Color.LightGray;
                    _currentState = State.Hovered;
                    OnClick();
                }
                else
                {
                    _color = Color.White;
                    _currentState = State.Normal;
                }
            }
        }

        protected virtual void OnClick()
        {

        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(_texture, new Vector2(_position.X - (_texture.Width / 2), _position.Y - (_texture.Height / 2)), null, _color, 0, Vector2.Zero, _scale, SpriteEffects.None, 0);
        }
    }
}
