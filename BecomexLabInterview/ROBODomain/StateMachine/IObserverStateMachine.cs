namespace ROBODomain.StateMachine
{
    public interface IObserverStateMachine
    {
        IStateMachine StateMachine { get; }

        void Update(IObservableStateMachine observable);
    }
}