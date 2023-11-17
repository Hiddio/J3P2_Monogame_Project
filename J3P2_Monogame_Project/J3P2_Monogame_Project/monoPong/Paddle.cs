using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3P2_Monogame_Project.monoPong
{
    class Paddle : Framework.GameObject
    {

        public Paddle(Vector2 pos, float scale, GraphicsDevice pGraphicsDevice) : base(pos, scale, pGraphicsDevice)
        {

        }
    }
}
