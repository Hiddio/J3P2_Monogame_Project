using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame_jaar3_WillemijnSterken.Assignment2;
using SharpDX.Direct2D1;


namespace J3P2_Monogame_Project.Willemijn.Assignment3
{
    public class Enemy : GameObject
    {
        private List<EnemyState> _enemyStates;
        private Knight _knight;
        private EnemyStateManager _enemyStateManager;
        public float _speed;
        private List<Flag> _flags;
        private EnemyState currentState;
        private float time = 0;

        public Enemy(float extraSpeed, SceneManager sceneManager, Vector2 position, GraphicsDeviceManager graphics, Texture2D texture, Knight knight, List<Flag> flags) : base(sceneManager, position, graphics, texture)
        {
            _knight = knight;

            _enemyStates = new List<EnemyState>();
            _flags = flags;
            
            PatrollingState patrollingState = new PatrollingState(extraSpeed, _knight, _flags, this, _enemyStateManager, sceneManager);
            IdlingState idlingState = new IdlingState(_knight, _flags, this, _enemyStateManager, sceneManager);
            ChasingState chasingState = new ChasingState(extraSpeed, _knight, _flags, this, _enemyStateManager, sceneManager);

            _enemyStates.Add(chasingState);
            _enemyStates.Add(patrollingState);
            _enemyStates.Add(idlingState);

            _enemyStateManager = new EnemyStateManager(_enemyStates);
            for (int i = 0; i < _enemyStates.Count; i++)
            {
                _enemyStates[i].LoadObject(_enemyStateManager);
            }
            _enemyStateManager.GetCurrentState().EnterState();
            currentState = _enemyStateManager.GetCurrentState();
        }

        public override void Update(GameTime gameTime)
        {
            if (currentState != _enemyStateManager.GetCurrentState())
            {
                time = currentState.ExitState(gameTime);
                currentState = _enemyStateManager.GetCurrentState();
                _enemyStateManager.GetCurrentState().EnterState();
            }
            _enemyStateManager.GetCurrentState().Update(gameTime, time);
        }
    }
}
