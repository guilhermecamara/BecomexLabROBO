using System;
using System.Collections.Generic;
using System.Text;

namespace ROBODomain.StateMachine
{
    public class ObserverStateMachine : IObserverStateMachine
    {
        public IStateMachine StateMachine { get; }

        public ObserverStateMachine(IStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        public void Update(IObservableStateMachine observable)
        {
            // TODO
        }
    }
}
