using System;
using System.Collections.Generic;
using System.Text;

namespace ROBODomain.StateMachine {
    public class State : IState
    {
        public StateEnum StateName { get ; set; }
    }
}
