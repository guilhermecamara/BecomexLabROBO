using System;
using System.Collections.Generic;
using System.Text;

namespace ROBO.Core
{
    public class Inclination : IObservableBodyPart
    {
        private IList<IObserverBodyPart> _subjects { get; set; } = new List<IObserverBodyPart>();
        public string Name
        {
            get
            {
                return $"Inclination";
            }
        }

        public IStateMachine StateMachine { get; }

        public Inclination(IStateMachine stateMachine)
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
