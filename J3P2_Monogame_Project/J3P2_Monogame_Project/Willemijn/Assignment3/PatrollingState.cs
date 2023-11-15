using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class PatrollingState : EnemyState
    {
        private int _flagNumber = 0;
        private float _extraSpeed;
        public PatrollingState(float extraSpeed, Knight knight, List<Flag> flags, Enemy enemy, EnemyStateManager enemyStateManager, SceneManager sceneManager) : base(knight, flags, enemy, enemyStateManager, sceneManager)
        {
            _enemyStateManager = enemyStateManager;
            _extraSpeed = extraSpeed;
        }
        public override void EnterState()
        {
            _enemy._speed = 100f + _extraSpeed;
        }

        public override void Update(GameTime gameTime, float time)
        {
            float deltaTime = (float)gameTime.TotalGameTime.TotalSeconds - time;
            distancePlayer = Vector2.Distance(_enemy._position, _knight._position);
            if (distancePlayer < 2 * _enemy._texture.Width)
            {
                _enemyStateManager.ChangeState(0);
            }
            else if (deltaTime > 15)
            {
                _enemyStateManager.ChangeState(2);
            }
            else
            {
                float distanceEnemy = Vector2.Distance(_enemy._position, _flags[_flagNumber]._position);
                if (distanceEnemy > _enemy._texture.Width)
                {
                    walkingVector = _flags[_flagNumber]._position - _enemy._position;
                    walkingVector.Normalize();
                    _enemy._position += walkingVector * _enemy._speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    _flagNumber++;
                    if (_flagNumber == _flags.Count) _flagNumber = 0;
                }
            }
        }
    }
}