using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ROBODomain {
    public class StateMachine : IStateMachine 
    {
        private IEnumerable<IState> _states { get; set; }
        private int _currentState { get; set; }
        public bool CanModify { get; set; }

        /// <summary>
        /// Always initializes with resting state. If the resting state is not provided in the states list, throws an exception.
        /// </summary>
        /// <param name="states">List of possible states for this state machine</param>
        public StateMachine(IEnumerable<IState> states) 
        {
            if (states.Any(s => s.StateName == StateEnum.Resting) == false)
                throw new ArgumentException("Missing Resting IState");

            _states = states;
            _currentState = _states.ToList().FindIndex(0, s => s.StateName == StateEnum.Resting);
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
