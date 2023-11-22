using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace J3P2_Monogame_Project.Framework
{
    class Button : GameObject
    {
        protected SpriteFont _textFont;
        protected MouseState _mouseState;
        protected Point _mousePosition;
        protected enum State
        {
            Normal, 
            Hovered,
            Pressed
        }
        protected State _currentState;
        public Button(Vector2 pPosition, Vector2 pScale, GraphicsDevice pGraphicsDevice, Rectangle pRectangle) : base(pPosition, pScale, pGraphicsDevice, pRectangle)
        {
            // _textFont = game1.Content.Load<SpriteFont>("BrandonGrotesqueBold");
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
        }
        public override void Draw(SpriteBatch pSpriteBatch)
        {

        }
        protected void NormalMode()
        {
            if (HitBox.Contains(_mousePosition))
            {
                // color change light grey
                _currentState = State.Hovered;
            }
        }
        protected void HoverMode()
        {
            if (!HitBox.Contains(_mousePosition))
            {
                // color change white
                _currentState = State.Normal;
            }
            if (_mouseState.LeftButton == ButtonState.Pressed)
            {
                // color change dark grey
                _currentState = State.Pressed;
            }
        }
        protected virtual void PressedMode()
        {
            if (_mouseState.LeftButton == ButtonState.Released)
            {
                if (HitBox.Contains(_mousePosition))
                {
                    // color change light grey
                    _currentState = State.Hovered;
                }
                else
                {
                    // color change white
                    _currentState = State.Normal;
                }
            }
        }
    }
}
