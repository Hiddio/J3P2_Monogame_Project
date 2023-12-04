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
    class MenuButton : Button
    {
        private SceneManager _sceneManager;
        public MenuButton(Vector2 pPosition, float pScale, Texture2D pTexture, SceneManager pSceneManager) : base(pPosition, pScale, pTexture, Color.White)
        {
            _sceneManager = pSceneManager;
        }

        protected override void OnClick()
        {
            _sceneManager.ChangeScene(0);
        }
    }
}
