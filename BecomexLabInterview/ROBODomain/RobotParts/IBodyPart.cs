using ROBODomain.StateMachine;

namespace ROBODomain.RobotParts
{
    public interface IBodyPart
    {
        string Identifier { get; set; }
        IObservableStateMachine ObservableStateMachine { get; }
        IObserverStateMachine ObserverStateMachine { get; }
    }
}