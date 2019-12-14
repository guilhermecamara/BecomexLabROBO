namespace ROBODomain.RobotStateMachine.StateMachineStrategies
{
    public interface IUpdateStrategy
    {        
        void Update(IObservableStateMachine observable, IObserverStateMachine context);
    }
}