using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ROBODomain.StateMachine {
    public class StateMachine : IStateMachine 
    {
        private IEnumerable<IState> _states { get; set; }
        private int _currentState { get; set; }
        public bool CanModify { get; protected set; }

        public StateMachine(IEnumerable<IState> states, int initialState) 
        {
            _states = states;
            _currentState = initialState;
        }

        public IState GetState() 
        {
            return _states.ElementAt(_currentState);
        }

        public bool Next() 
        {
            if (CanModify && _currentState < _states.Count() - 1) {

                _currentState++;
                return true;
            }

            return false;
        }

        public bool Previous() 
        {
            if (CanModify && _currentState > 0) 
            {

                _currentState--;
                return true;
            }

            return false;
        }
    }
}
