using ROBODomain.StateMachine;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROBODomain.RobotParts
{
    public class Arm : IArm
    {
        public string Identifier { get; set; }
        public IObservableStateMachine ObservableStateMachine { get; }
        public IObserverStateMachine ObserverStateMachine { get; }
        public BodySideEnum BodySide { get ; set; }
    }
}
