namespace ROBODomain.StateMachine {
    public interface IStateMachine {
        bool CanModify { get; }

        IState GetState();
        bool Next();
        bool Previous();
    }
}