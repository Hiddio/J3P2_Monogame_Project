using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using J3P2_Monogame_Project.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P2_Monogame_Project.monoPong
{
    class PlayButton : Button
    {
        private SceneManager _sceneManager;
        public PlayButton(Vector2 pPosition, float pScale, Texture2D pTexture, SceneManager pSceneManager) : base(pPosition, pScale, pTexture, Color.White)
        {
            _sceneManager = pSceneManager;
        }

        public override void Update(GameTime pGameTime)
        {
            Console.WriteLine(lastMouseClick);
            base.Update(pGameTime);
        }

        protected override void PressedMode()
        {
            //Console.WriteLine(lastMouseClick);
            if (_mouseState.LeftButton == ButtonState.Pressed & lastMouseClick == ButtonState.Released)
            {

                _sceneManager.ChangeScene(_sceneManager.GetCurrentSceneInt() + 1);
            }
            base.PressedMode();
        }
    }
}
