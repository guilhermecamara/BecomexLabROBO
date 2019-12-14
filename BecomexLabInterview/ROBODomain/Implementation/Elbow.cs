using System;
using System.Collections.Generic;
using System.Text;

namespace ROBODomain
{
    public class Elbow : IObservableBodyPart
    {
        private IList<IObserverBodyPart> _subjects { get; set; } = new List<IObserverBodyPart>();
        public string Name
        {
            get
            {
                return $"Elbow";
            }
        }
        public IStateMachine StateMachine { get; }

        public Elbow(IStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }        

        public void Attach(IObserverBodyPart subject)
        {
            _subjects.Add(subject);
            subject.Update(this);
        }

        public void Detach(IObserverBodyPart subject)
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
