﻿using System;
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
        SceneManager _sceneManager;
        public PlayButton(Vector2 pPosition, Vector2 pScale, GraphicsDevice pGraphics, Rectangle pRectangle, SceneManager pSceneManager) : base(pPosition, pScale, pGraphics, pRectangle)
        {
            _sceneManager = pSceneManager;
        }

        protected override void PressedMode()
        {
            _sceneManager.ChangeScene(1);
        }
    }
}
