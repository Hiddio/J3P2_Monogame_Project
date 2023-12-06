using J3P2_Monogame_Project.monoPong;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace J3P2_Monogame_Project
{
    public class WinOrLoseManager
    {
        private Dictionary<Paddle, int> activePaddles;
        public WinOrLoseManager(Dictionary<Paddle, int> pPaddles) 
        {
            activePaddles = pPaddles;
        }

        public void Update()
        {
            Console.WriteLine(activePaddles.Keys);
        }
    }
}
