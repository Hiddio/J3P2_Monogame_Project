using J3P2_Monogame_Project.monoPong;
using J3P2_Monogame_Project.monoPong.Thom;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace J3P2_Monogame_Project
{
    public class Wall
    {

        // Objects
        private Ball _ball;
        private Paddle _paddle;
        private GraphicsDevice _device;
        private Game1 _game;

        // Variables
        private float windowWidth;
        private float windowHeight;
        public Wall(GraphicsDevice pDevice, Ball pBall, Paddle pPaddle, Game1 pGame)
        {
            _device = pDevice;
            _ball = pBall;
            _paddle = pPaddle;
            _game = pGame;

            windowWidth = _device.Viewport.Width;
            windowHeight = _device.Viewport.Height;
        }
        public void Update()
        {
            CheckWallCollision();
        }
        public void CheckWallCollision()
        {
            // Paddle 1
            Console.WriteLine(_ball._position.X);
            if (_ball._position.X <= 1f)
            {
                _game._objects.Remove(_paddle);
            }
            // Paddle 2

            if (_ball._position.X >= windowWidth - 1f)
            {
                _game._objects.Remove(_paddle);
            }
            // Paddle 3
            if (_ball._position.Y <= 1f)
            {
                _game._objects.Remove(_paddle);
            }
            // Paddle 4
            if (_ball._position.Y >= windowHeight - 1f)
            {
                _game._objects.Remove(_paddle);
            }
        }
    }
}
