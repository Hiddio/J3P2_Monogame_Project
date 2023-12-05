using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using J3P2_Monogame_Project.Framework;
using System;

namespace J3P2_Monogame_Project.monoPong.Thom
{
    internal class Ball : GameObject
    {
        public float _speed;
        private float _ballSpeed;
        public Vector2 _velocity = new Vector2(0,0);
        private bool firstTime = true;
        private GraphicsDevice _device;

        float angleInRadians;

        // debug
        Vector2 newObjectPos = new Vector2(0, 0);
        public Ball(Vector2 pPosition, float pScale, Texture2D pTexture, float pSpeed, GraphicsDevice pGraphicsDevice) : base(pPosition, pScale, pTexture)
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
            Console.WriteLine(_velocity);
            //_velocity = Vector2.Normalize(_velocity);
            //_position = _position + _velocity * (float)pGameTime.ElapsedGameTime.TotalSeconds * _speed;

            _velocity.X = _speed * (float)Math.Cos(angleInRadians);
            _velocity.Y = _speed * (float)Math.Cos(angleInRadians);


            _position += _velocity;
            //_position.X += _velocity.X;
            //_position.Y += _velocity.Y;
        }
        /// <summary>
        /// Update the ball's hitbox.
        /// </summary>
        public void BallCollision()
        {
           // Console.WriteLine(HitBox); debug for position
            //Invert velocity
            if (_position.X < 0 || _position.X > _device.Viewport.Width - HitBox.Width)
            {
                //_velocity.X *= -1;
                SpawnBallInMiddle();
            }
            if (_position.Y < 0 || _position.Y > _device.Viewport.Height - HitBox.Height)
            {
                SpawnBallInMiddle();
                _velocity.Y = -_velocity.Y;
            }
        }
        private void SpawnBallInMiddle()
        {
            _position = new Vector2(_device.Viewport.Width / 2, _device.Viewport.Height / 2);
            angleInRadians = GetRandomAngle();
            if (!firstTime)
            {
                _speed = _ballSpeed;
            }
            firstTime = false;
        }
        public void AddBallSpeed()
        {
            float addedBallSpeed;
            addedBallSpeed = ((_ballSpeed / 10) + 10 * 2.25f);
            _speed += addedBallSpeed;
        }
        private float GetRandomAngle()
        {
            float angle;
            Random rng = new Random();
            do
            {
                angle = rng.Next(1, 361);
            }
            while (!(angle >= 0 && angle <= 120) && (angle < 150 || angle > 210));
            Console.WriteLine(angle);
            return angle;
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
