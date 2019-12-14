using System.Collections.Generic;

namespace ROBO.Core {
    public interface IStateMachine {
        bool CanModify { get; set; }
        IEnumerable<IState> States { get; }

        void SetStates(IEnumerable<IState> states);
        IState GetState();
        bool Next();
        bool Previous();
    }
}