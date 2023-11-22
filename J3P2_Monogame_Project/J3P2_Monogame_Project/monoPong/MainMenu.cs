using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using J3P2_Monogame_Project.Framework;
using SharpDX.Direct2D1.Effects;

namespace J3P2_Monogame_Project.monoPong
{
    class MainMenu : Scene
    {
        Rectangle _rectangle;
        public MainMenu(SpriteBatch pSpriteBatch, GraphicsDeviceManager pGraphics, Vector2 pScale) : base(pSpriteBatch, pGraphics, pScale)
        {

        }

        public override void LoadContent(SceneManager sceneManager)
        {
            _rectangle = new Rectangle(_graphics.GraphicsDevice.Viewport.Width / 2, _graphics.GraphicsDevice.Viewport.Height / 2, 200, 100);
            PlayButton _playButton = new PlayButton(new Vector2(-50), _scale, _graphics.GraphicsDevice, _rectangle, sceneManager);
            QuitButton _quitButton = new QuitButton(new Vector2(50), _scale, _graphics.GraphicsDevice, _rectangle, sceneManager);

            base.LoadContent(sceneManager);
        }
    }
}
