using ROBODomain.RobotStateMachine;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROBODomain.RobotParts
{
    public class Arm : IArm
    {
        public int Id { get; set; }
        public IObservableStateMachine ElbowStateMachine { get; }
        public IObserverStateMachine WristStateMachine { get; }
        public BodySideEnum BodySide { get ; set; }

        public Arm(IObservableStateMachine elbowStateMachine, IObserverStateMachine wristStateMachine)
        {
            ElbowStateMachine = elbowStateMachine;
            WristStateMachine = wristStateMachine;
        }
    }
}
