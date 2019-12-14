using ROBODomain.RobotStateMachine.StateMachineStrategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROBODomain.RobotStateMachine
{
    public class ObserverStateMachine : IObserverStateMachine
    {
        private IUpdateStrategy _updateStrategy { get; set; }
        public IStateMachine StateMachine { get; }

        public ObserverStateMachine(IStateMachine stateMachine, IUpdateStrategy updateStrategy)
        {
            StateMachine = stateMachine;
            _updateStrategy = updateStrategy;
        }

        public void Update(IObservableStateMachine observable)
        {
            _updateStrategy.Update(observable, this);
        }
    }
}
