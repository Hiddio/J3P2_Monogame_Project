using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using J3P2_Monogame_Project.Framework;
using System;

namespace J3P2_Monogame_Project.monoPong.Thom
{
    internal class Ball : GameObject
    {
        GraphicsDevice _device;
        float _speed = 150f;
        public Ball(Vector2 pPosition, float pScale, GraphicsDevice pGraphicsDevice, Rectangle pRectangle ) : base(pPosition, pScale, pGraphicsDevice, pRectangle)
        {
            _device = pGraphicsDevice;
        }
        // ball update
        public override void Update(GameTime pGameTime)
        {
            ClampBall();
            UpdateHitbox();
            BallMovement(pGameTime);
        }
        /// <summary>
        /// Clamps the ball so it can't leave the game-window.
        /// </summary>
        private void ClampBall()
        {
            float windowWidth = _device.Viewport.Width;
            float windowHeight = _device.Viewport.Height;

            _position = new Vector2(Math.Clamp(_position.X, 0, windowWidth - _hitbox.Value.Width), Math.Clamp(_position.Y, 0, windowHeight - _hitbox.Value.Width));

            Console.WriteLine(_hitbox.Value.Width);
        }
        /// <summary>
        /// Handles all the logic for the ball's movement.
        /// </summary>
        /// <param name="pGameTime"></param>
        private void BallMovement(GameTime pGameTime)
        {
            _position.X += (float)pGameTime.ElapsedGameTime.TotalSeconds * _speed;
            _position.Y += (float)pGameTime.ElapsedGameTime.TotalSeconds * _speed;
        }
        /// <summary>
        /// Update the ball's hitbox.
        /// </summary>
        private void UpdateHitbox()
        {
            _hitbox = new Rectangle((int)_scale, (int)_scale, (int)_scale, (int)_scale);
        }
        private Vector2 GetRandomDirection()
        {
            return new Vector2(0,0);
        }



        // give ball speed



        // bounce ball against walls







        // ball draw
        public override void DrawRectangle(SpriteBatch pSpriteBatch)
        {
            base.DrawRectangle(pSpriteBatch);
        }

    }
}
