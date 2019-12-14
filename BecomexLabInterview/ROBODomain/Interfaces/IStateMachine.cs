namespace ROBODomain {
    public interface IStateMachine {
        bool CanModify { get; set; }

        IState GetState();
        bool Next();
        bool Previous();
    }
}