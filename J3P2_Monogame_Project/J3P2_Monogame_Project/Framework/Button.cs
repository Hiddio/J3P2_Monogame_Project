using Microsoft.Xna.Framework;
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
        private ButtonState lastMouseClick = Mouse.GetState().LeftButton;

        protected enum State
        {
            Normal, 
            Hovered,
            Pressed
        }
        protected State _currentState;
        public Button(Vector2 pPosition, float pScale, Texture2D pTexture, Color pColor) : base(pPosition, pScale, pTexture, pColor)
        {
            
            //_textFont = game1.Content.Load<SpriteFont>("BrandonGrotesqueBold");

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
        protected void NormalMode()
        {
            if (HitBox.Contains(_mousePosition))
            {
                _color = Color.LightGray;
                _currentState = State.Hovered;
            }
        }
        protected void HoverMode()
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
                }
                else
                {
                    _color = Color.White;
                    _currentState = State.Normal;
                }
            }
        }
    }
}
