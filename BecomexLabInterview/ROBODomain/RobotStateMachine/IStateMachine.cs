namespace ROBODomain.RobotStateMachine {
    public interface IStateMachine {
        bool CanModify { get; set; }

        IState GetState();
        bool Next();
        bool Previous();
    }
}