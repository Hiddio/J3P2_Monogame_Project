using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace J3P2_Monogame_Project.monoPong
{
    class Paddle : Framework.GameObject
    {
        Vector2 _direction;
        int _paddleNumber;
        public Paddle(Vector2 pPosition, float pScale, Texture2D pTexture, int pPaddleNumber) : base(pPosition, pScale, pTexture)
        {
            _paddleNumber = pPaddleNumber;
        }

        public override void Update(GameTime pGameTime)
        {
            MovementInput(_paddleNumber, pGameTime);
        }

        void Movement(Vector2 pDirection, float pSpeed, GameTime pGameTime)
        {
            if(pDirection !=  Vector2.Zero)
            {
                pDirection.Normalize();
            }
            _position += pDirection * (float)pGameTime.ElapsedGameTime.TotalSeconds * pSpeed;
        }

        void MovementInput(int paddleNum, GameTime pGameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            GamePadState padOneState = GamePad.GetState(PlayerIndex.One);
            GamePadState padTwoState = GamePad.GetState(PlayerIndex.Two);
            _direction = new Vector2(0, 0);
            
            switch (paddleNum)
            {
                case 0:
                    if (keyState.IsKeyDown(Keys.W))
                    {
                        _direction.Y--;
                    }
                    if (keyState.IsKeyDown(Keys.S))
                    {
                        _direction.Y++;
                    }
                    break;
                case 1:
                    if (keyState.IsKeyDown(Keys.Up))
                    {
                        _direction.Y--;
                    }
                    if (keyState.IsKeyDown(Keys.Down))
                    {
                        _direction.Y++;
                    }
                    break;
                case 2:
                    Console.WriteLine("test1");
                    if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
                    {
                        Console.WriteLine("test2");
                        _direction.X--;
                    }
                    if (padOneState.DPad.Right == ButtonState.Pressed)
                    {
                        _direction.X++;
                    }
                    break;
                case 3:
                    if (padTwoState.DPad.Left == ButtonState.Pressed)
                    {
                        _direction.X--;
                    }
                    if (padTwoState.DPad.Right == ButtonState.Pressed)
                    {
                        _direction.X++;
                    }
                    break;
            }

            Movement(_direction, 500, pGameTime);
        }
    }
}
