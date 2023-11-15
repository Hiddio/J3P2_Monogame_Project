using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P2_Monogame_Project.Willemijn.Assignment3
{
    public class Buttons : GameObject
    {
        private Color hoverColor = Color.Yellow;
        private Color normalColor = Color.White;
        private Color pressedColor = Color.Turquoise;
        private StateButton stateButton = StateButton.Normal;

        private ButtonState lastMouseClick = Mouse.GetState().LeftButton;
        private ButtonState mouseClick;
        private Vector2 mousePosition;
        private float distance;
        public Buttons(SceneManager sceneManager, Vector2 position, GraphicsDeviceManager graphics, Texture2D texture) : base(sceneManager, position, graphics, texture)
        {

        }
        public override void Update(GameTime gameTime)
        {
            mouseClick = Mouse.GetState().LeftButton;
            mousePosition = Mouse.GetState().Position.ToVector2();
            distance = Vector2.Distance(_position, mousePosition);
            if (stateButton == StateButton.Normal)
            {
                NormalState();
            }
            else if (stateButton == StateButton.Hovered)
            {
                HoveredState();
            }
            else if (stateButton == StateButton.Pressed)
            {
                PressedState();
            }
            lastMouseClick = mouseClick;
        }

        public void NormalState()
        {
            if (distance <= _texture.Height / 2)
            {
                stateButton = StateButton.Hovered;
                color = hoverColor;
            }
        }

        public void HoveredState()
        {
            if (distance > _texture.Height / 2)
            {
                stateButton = StateButton.Normal;
                color = normalColor;
            }
            if (mouseClick == ButtonState.Pressed & lastMouseClick == ButtonState.Released)
            {
                stateButton = StateButton.Pressed;
                color = pressedColor;
                    
            }
        }

        public void PressedState()
        {
            if (mouseClick == ButtonState.Released & lastMouseClick == ButtonState.Pressed)
            {
                if (distance <= _texture.Height / 2)
                {
                    stateButton = StateButton.Hovered;
                    color = hoverColor;
                    OnClick();
                }
                else
                {
                    stateButton = StateButton.Normal;
                    color = normalColor;
                }
                   
            }
        }

        public virtual void OnClick()
        {

        }


  

    }
}
