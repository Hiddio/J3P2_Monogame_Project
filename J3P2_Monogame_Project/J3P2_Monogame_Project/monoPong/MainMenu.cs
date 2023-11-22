using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using J3P2_Monogame_Project.Framework;
using System.Drawing;
using SharpDX.Direct2D1.Effects;

namespace J3P2_Monogame_Project.monoPong
{
    class MainMenu : Scene
    {
        public MainMenu(SpriteBatch pSpriteBatch, GraphicsDeviceManager pGraphics, float pScale) : base(pSpriteBatch, pGraphics, pScale)
        {

        }

        public override void LoadContent(SceneManager sceneManager)
        {
            PlayButton _playButton = new PlayButton(new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2, (_graphics.GraphicsDevice.Viewport.Height / 2) - 50), scale, _graphics, rectangle, sceneManager);
            QuitButton _quitButton = new QuitButton(new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2, (_graphics.GraphicsDevice.Viewport.Height / 2) + 50), scale, _graphics, rectangle, sceneManager);

            base.LoadContent(sceneManager);
        }
    }
}
