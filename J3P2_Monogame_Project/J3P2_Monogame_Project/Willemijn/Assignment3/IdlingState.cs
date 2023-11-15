using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame_jaar3_WillemijnSterken.Assignment2;
using SharpDX.Direct3D9;

namespace J3P2_Monogame_Project.Willemijn.Assignment3
{
    public class IdlingState : EnemyState
    {
        private float timeIdling;
        public IdlingState(Knight knight, List<Flag> flags, Enemy enemy, EnemyStateManager enemyStateManager, SceneManager sceneManager) : base(knight, flags, enemy, enemyStateManager, sceneManager)
        {
            _enemyStateManager = enemyStateManager;
        }

        public override void EnterState()
        {
            _enemy._speed = 0f;
            timeSet = false;
        }
        public override void Update(GameTime gameTime, float time)
        {
            if (!timeSet)
            {
                timeIdling = (float)gameTime.TotalGameTime.TotalSeconds;
                timeSet = true;
            }
            
            float deltaTime = (float)gameTime.TotalGameTime.TotalSeconds - timeIdling;
            distancePlayer = Vector2.Distance(_enemy._position, _knight._position);
            if (distancePlayer < 2 * _enemy._texture.Width)
            {
                _enemyStateManager.ChangeState(0);
            }
            else if (deltaTime > 3)
            {
                _enemyStateManager.ChangeState(1);
            }
        }
        public override float ExitState(GameTime gameTime)
        {
            return time = (float)gameTime.TotalGameTime.TotalSeconds;
        }
    }
}