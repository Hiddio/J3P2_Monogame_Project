using Microsoft.Xna.Framework;
using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3P2_Monogame_Project.Willemijn.Assignment3
{
    public class EnemyStateManager
    {
        private List<EnemyState> _states;
        private EnemyState _currentState;

        public EnemyStateManager(List<EnemyState> states)
        {
            _states = states;
            _currentState = _states[0];
        }

        public void ChangeState(int newState)
        {
            _currentState = _states[newState];
        }


        public EnemyState GetCurrentState()
        {
            return _currentState;
        }

        public int GetCurrentStateInt()
        {
            return _states.IndexOf(_currentState);
        }
    }
}
