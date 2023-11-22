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
    public class ChasingState : EnemyState
    {
        private bool lastCollided;
        private float _extraSpeed;

        public ChasingState(float extraSpeed, Knight knight, List<Flag> flags, Enemy enemy, EnemyStateManager enemyStateManager, SceneManager sceneManager) : base(knight, flags, enemy, enemyStateManager, sceneManager)
        {
            _enemyStateManager = enemyStateManager;
            _sceneManager = sceneManager;
            _extraSpeed = extraSpeed;

        }

        public override void EnterState()
        {
            _enemy._speed = 120f + _extraSpeed;
        }

        public override void Update(GameTime gameTime, float time)
        {
            walkingVector = _knight._position - _enemy._position;
            walkingVector.Normalize();
            _enemy._position += walkingVector* _enemy._speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            distancePlayer = Vector2.Distance(_enemy._position, _knight._position);
            if (distancePlayer < _enemy._texture.Width & !lastCollided)
            {
                CloseToKnight();
            }
            else if (distancePlayer > 2 * _enemy._texture.Width)
            {
                _enemyStateManager.ChangeState(2);
            }
            if (distancePlayer > 1.2 * _enemy._texture.Width)
            {
                lastCollided = false;
            }
        }

        public void CloseToKnight()
        {
            lastCollided = true;
            if (_knight._texture == _knight._textureKnightWeaponShield)
            {
                _sceneManager.GetCurrentScene().RemoveObject(_enemy);
                _sceneManager._won++;
                if (_sceneManager._scenes.Count == _sceneManager._won)
                {
                    _sceneManager.ChangeScene(4);
                }

            }
            else if (_knight._hearts.Any())
            {
                _knight._hearts.RemoveAt(0);
            }
            else
            {
                _sceneManager.ChangeScene(3);
            }
        }
    }
}

