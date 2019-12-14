using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ROBODomain.RobotStateMachine {
    public class ObservableStateMachine : IObservableStateMachine
    {
        public IStateMachine StateMachine { get; }

        private IList<IObserverStateMachine> _subjects { get; set; }

        public ObservableStateMachine(IStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        public void Attach(IObserverStateMachine subject)
        {
            _subjects.Add(subject);
        }

        public void Detach(IObserverStateMachine subject)
        {
            _subjects.Remove(subject);
        }

        public void Notify()
        {
            foreach (var subject in _subjects)
            {
                subject.Update(this);
            }
        }
    }
}
