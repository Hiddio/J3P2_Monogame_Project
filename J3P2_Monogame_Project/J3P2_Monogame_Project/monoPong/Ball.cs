using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using J3P2_Monogame_Project.Framework;
using System;

namespace J3P2_Monogame_Project.monoPong
{
    public class Ball : GameObject
    {
        public float _speed;
        private float _ballSpeed;
        public Vector2 _velocity = Vector2.Zero;
        private bool firstTime = true;
        private GraphicsDevice _device;
        public Ball(Vector2 pPosition, float pScale ,Texture2D pTexture, float pSpeed, GraphicsDevice pGraphicsDevice) : base(pPosition, pScale, pTexture)
        {
            _speed = pSpeed;
            _device = pGraphicsDevice;
        }
        public override void Update(GameTime pGameTime)
        {
            ClampBall();
            //UpdateHitbox();
            BallMovement(pGameTime);
            BallCollision();
        }
        public override void Start()
        {
            SpawnBallInMiddle();
            _velocity = GetRandomDirection();
            _ballSpeed = _speed;
        }
        /// <summary>
        /// Clamps the ball so it can't leave the game-window.
        /// </summary>
        private void ClampBall()
        {
            float windowWidth = _device.Viewport.Width;
            float windowHeight = _device.Viewport.Height;

            _position = new Vector2(Math.Clamp(_position.X, 0, windowWidth - HitBox.Width), Math.Clamp(_position.Y, 0, windowHeight - HitBox.Height));
        }
        /// <summary>
        /// Handles all the logic for the ball's movement.
        /// </summary>
        /// <param name="pGameTime"></param>
        private void BallMovement(GameTime pGameTime)
        {
            //Update position every frame

            _velocity = Vector2.Normalize(_velocity);
            _position = _position + _velocity * (float)pGameTime.ElapsedGameTime.TotalSeconds * _speed;
        }
        /// <summary>
        /// Update the ball's hitbox.
        /// </summary>
        public void BallCollision()
        {
            Console.WriteLine(HitBox);
            //Invert velocity
            if (_position.X < 0 || _position.X > _device.Viewport.Width - HitBox.Width)
            {
                //_velocity.X *= -1;
                SpawnBallInMiddle();
            }
            if (_position.Y < 0 || _position.Y > _device.Viewport.Height - HitBox.Height)
            {
                //SpawnBallInMiddle();
                _velocity.Y *= -1;
            }
        }
        private void SpawnBallInMiddle()
        {
            _position = new Vector2(_device.Viewport.Width / 2, _device.Viewport.Height / 2);
            _velocity = GetRandomDirection();
            if (!firstTime)
            {
                _speed = _ballSpeed;
            }
            firstTime = false;
        }
        public void AddBallSpeed()
        {
            float addedBallSpeed;
            addedBallSpeed = _ballSpeed / 10 + 10 * 2.25f;
            _speed += addedBallSpeed;
        }
        private Vector2 GetRandomDirection()
        {
            /*
             * 
             * GET V2 X,Y RANDOM NUMBERS BETWEEN 60,-60 AND 150,210
             * 
             * */
            Random random = new Random();
            // Returns a random floating-point number between -1 and 1
            return new Vector2((float)(random.NextDouble() * 2 - 1), (float)(random.NextDouble() * 2 - 1));
        }

        // bounce ball against walls

        // ball draw

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            //base.Draw(pSpriteBatch);
            base.Draw(pSpriteBatch);
        }
        //public override void DrawRectangle(SpriteBatch pSpriteBatch)
        //{
        //    base.DrawRectangle(pSpriteBatch);
        //}

    }
}
