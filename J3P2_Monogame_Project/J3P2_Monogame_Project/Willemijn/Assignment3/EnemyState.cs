using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace J3P2_Monogame_Project.Willemijn.Assignment3
{
    public class EnemyState
    {
        public EnemyStateManager _enemyStateManager;
        protected Knight _knight;
        protected List<Flag> _flags;
        protected Vector2 walkingVector;
        protected float distancePlayer;
        protected float time;
        protected Enemy _enemy;
        public bool timeSet = false;
        protected SceneManager _sceneManager;
        public EnemyState(Knight knight, List<Flag> flags, Enemy enemy, EnemyStateManager enemyStateManager, SceneManager sceneManager)
        {
            _knight = knight;
            _flags = flags;
            _enemy = enemy;
            _enemyStateManager = enemyStateManager;
            _sceneManager = sceneManager;
        }

        public virtual void LoadObject(EnemyStateManager enemyStateManager)
        {
            _enemyStateManager = enemyStateManager;
        }
        public virtual void EnterState()
        {
        }
        public virtual float ExitState(GameTime gameTime)
        {
            return time;
        }

        public virtual void Update(GameTime gameTime, float time)
        {

        }
    }
}

