using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ROBO.Core.Entities {
    public class StateMachine : IStateMachine 
    {
        public int CurrentState { get; set; }
        public IEnumerable<IState> States { get; set; }
        public bool CanModify { get; set; } = true;

        /// <summary>
        // If the resting state is not provided in the states list, throws an exception.
        /// </summary>
        /// <param name="states">List of possible states for this state machine</param>
        public void SetStates(IEnumerable<IState> states) 
        {
            if (states.Any(s => s.StateEnum == StateEnum.Resting) == false)
                throw new ArgumentException("Missing Resting IState");

            States = states;
            CurrentState = States.ToList().FindIndex(0, s => s.StateEnum == StateEnum.Resting);
        }

        public IState GetState() 
        {
            return States.ElementAt(CurrentState);
        }

        public bool Next() 
        {
            if (CanModify && CurrentState < States.Count() - 1) {

                CurrentState++;
                return true;
            }

            return false;
        }

        public bool Previous() 
        {
            if (CanModify && CurrentState > 0) 
            {
                CurrentState--;
                return true;
            }

            return false;
        }
    }
}
