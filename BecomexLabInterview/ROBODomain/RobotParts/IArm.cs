using ROBODomain.RobotStateMachine;

namespace ROBODomain.RobotParts
{
    public interface IArm : IBodyPart
    {
        BodySideEnum BodySide { get; set; }

        IObservableStateMachine ElbowStateMachine { get; }
        IObserverStateMachine WristStateMachine { get; }
    }
}