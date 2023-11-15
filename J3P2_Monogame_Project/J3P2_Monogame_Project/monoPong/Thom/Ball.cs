using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using J3P2_Monogame_Project.Framework;

namespace J3P2_Monogame_Project.monoPong.Thom
{
    internal class Ball : GameObject
    {
        GraphicsDevice _device;
        float _speed = 5f;
        float direction = 360f;
        
        
        public Ball(Vector2 pPosition, float pScale, GraphicsDevice pGraphicsDevice) : base(pPosition, pScale, pGraphicsDevice)
        {
            _device = pGraphicsDevice;
        }

        // wall bounds
        



        // give ball speed



        // bounce ball against walls



        // ball update
        public override void Update(GameTime pGameTime)
        {
           
        }



        // ball draw
        public override void DrawRectangle(SpriteBatch pSpriteBatch)
        {
            base.DrawRectangle(pSpriteBatch);
        }

    }
}
