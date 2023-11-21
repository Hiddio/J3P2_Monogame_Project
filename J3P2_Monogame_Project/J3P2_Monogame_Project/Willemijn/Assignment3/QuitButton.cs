using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P2_Monogame_Project.Willemijn.Assignment3
{
    public class QuitButton : Button
    {
        public QuitButton(SceneManager sceneManager, Vector2 position, GraphicsDeviceManager graphics, Texture2D texture) : base(sceneManager, position, graphics, texture)
        {

        }

        public override void OnClick()
        {
            _sceneManager.CloseGame();
        }
    }
}
