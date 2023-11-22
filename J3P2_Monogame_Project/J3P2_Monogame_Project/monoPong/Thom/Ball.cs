using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using J3P2_Monogame_Project.Framework;
using System;

namespace J3P2_Monogame_Project.monoPong.Thom
{
    internal class Ball : GameObject
    {
        private float _speed;
        private Vector2 _velocity = Vector2.Zero;
        public Ball(Vector2 pPosition, float pScale, GraphicsDevice pGraphicsDevice, Rectangle pRectangle, float pSpeed) : base(pPosition, pScale, pGraphicsDevice, pRectangle)
        {
            _speed = pSpeed;
        }
        // ball update
        public override void Update(GameTime pGameTime)
        {
            ClampBall();
            UpdateHitbox();
            BallMovement(pGameTime);
        }
        public override void Start() 
        {
            SpawnBallInMiddle();
            _velocity = GetRandomDirection();
            _velocity.Normalize();
            Console.WriteLine(_velocity);
        }
        /// <summary>
        /// Clamps the ball so it can't leave the game-window.
        /// </summary>
        private void ClampBall()
        {
            float windowWidth = _graphicsDevice.Viewport.Width;
            float windowHeight = _graphicsDevice.Viewport.Height;

            _position = new Vector2(Math.Clamp(_position.X, 0, windowWidth - _hitbox.Value.Width), Math.Clamp(_position.Y, 0, windowHeight - _hitbox.Value.Height));
        }
        /// <summary>
        /// Handles all the logic for the ball's movement.
        /// </summary>
        /// <param name="pGameTime"></param>
        private void BallMovement(GameTime pGameTime)
        {
            //Update position every frame
            
            _position = _position + _velocity * (float)pGameTime.ElapsedGameTime.TotalSeconds * _speed;
            //Invert velocity
            if (_position.X < 0 || _position.X > _graphicsDevice.Viewport.Width - _hitbox.Value.Width) 
            {
                _velocity.X *= -1;
            }

            if (_position.Y < 0 || _position.Y > _graphicsDevice.Viewport.Height - _hitbox.Value.Height)
            {
                _velocity.Y *= -1;
            }
        }
        /// <summary>
        /// Update the ball's hitbox.
        /// </summary>
        private void UpdateHitbox()
        {
            _hitbox = new Rectangle((int)_scale, (int)_scale, (int)_scale, (int)_scale);
        }
        private void BounceBall()
        {

        }
        private void SpawnBallInMiddle()
        {
            _position = new Vector2(_graphicsDevice.Viewport.Width / 2, _graphicsDevice.Viewport.Height / 2);
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
        public override void DrawRectangle(SpriteBatch pSpriteBatch)
        {
            base.DrawRectangle(pSpriteBatch);
        }

    }
}
