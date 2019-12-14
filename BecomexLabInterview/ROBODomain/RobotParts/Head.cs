using ROBODomain.StateMachine;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROBODomain.RobotParts
{
    public class Head : IHead
    {
        public string Identifier { get; set; }
        public IObservableStateMachine ObservableStateMachine { get; }
        public IObserverStateMachine ObserverStateMachine { get; }        
    }
}
