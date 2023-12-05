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
    class FourPlayerButton : Button
    {
        private SceneManager _sceneManager;
        public FourPlayerButton(Vector2 pPosition, Texture2D pTexture, SceneManager pSceneManager) : base(pPosition, pTexture, Color.White)
        {
            _sceneManager = pSceneManager;
        }

        protected override void OnClick()
        {
            _playerAmount = 4;
            if (_sceneManager.GetCurrentSceneInt() < _sceneManager._scenes.Count)
            {
                _sceneManager.ChangeScene(_sceneManager.GetCurrentSceneInt() + 1);
            }
        }
    }
}
