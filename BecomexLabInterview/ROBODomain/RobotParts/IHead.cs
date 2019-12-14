using ROBODomain.RobotStateMachine;

namespace ROBODomain.RobotParts
{
    public interface IHead : IBodyPart
    {
        IObservableStateMachine HeadInclinationStateMachine { get; }
        IObserverStateMachine HeadRotationStateMachine { get; }
    }
}