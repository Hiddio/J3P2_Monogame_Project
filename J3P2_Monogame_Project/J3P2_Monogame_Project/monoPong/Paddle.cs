using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Xml;

namespace J3P2_Monogame_Project.monoPong
{
    class Paddle : Framework.GameObject
    {
        GameTime _gameTime;
        Vector2 _direction;
        public Paddle(Vector2 pPosition, float pScale, Texture2D pTexture) : base(pPosition, pScale, pTexture)
        {

        }

        public override void Update(GameTime pGameTime)
        {
            _gameTime = pGameTime;
            MovementInput();
        }

        void Movement(Vector2 pDirection, float pSpeed)
        {
            if(pDirection !=  Vector2.Zero)
            {
                pDirection.Normalize();
            }
            Console.WriteLine(pDirection);
            _position += pDirection * (float)_gameTime.ElapsedGameTime.TotalSeconds * pSpeed;
        }

        void MovementInput()
        {
            KeyboardState keyState = Keyboard.GetState();
            _direction.Y = 0;

            if (keyState.IsKeyDown(Keys.W))
            { 
                _direction.Y--;
            }
            if (keyState.IsKeyDown(Keys.S))
            {
                _direction.Y++;
            }
            Movement(_direction, 500);
        }

    }
}
