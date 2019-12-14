using ROBODomain.RobotStateMachine.StateMachineStrategies;

namespace ROBODomain.RobotStateMachine
{
    public interface IObserverStateMachine
    {
        IStateMachine StateMachine { get; }

        void Update(IObservableStateMachine observable);
    }
}