using ROBODomain.RobotStateMachine;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROBODomain.RobotParts
{
    public class Head : IHead
    {
        public int Id { get; set; }
        public IObservableStateMachine HeadInclinationStateMachine { get; }
        public IObserverStateMachine HeadRotationStateMachine { get; }

        public Head(IObservableStateMachine headInclinationStateMachine, IObserverStateMachine headRotationStateMachine)
        {
            HeadInclinationStateMachine = headInclinationStateMachine;
            HeadRotationStateMachine = headRotationStateMachine;
        }
    }
}
