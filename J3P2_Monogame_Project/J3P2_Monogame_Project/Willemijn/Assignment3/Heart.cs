using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P2_Monogame_Project.Willemijn.Assignment3
{
    public class Heart : GameObject
    {
        public Heart(SceneManager sceneManager, Vector2 position, GraphicsDeviceManager graphics) : base(sceneManager, position, graphics)
        {

        }
        public override void LoadObject(ContentManager content)
        {
            _texture = content.Load<Texture2D>("heart");

            _center = new Vector2(_texture.Width * 0.5f, _texture.Height * 0.5f);
        }
    }
}
