﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ROBO.Core.Entities
{
    public class Inclination : StateMachine, IObservableBodyPart
    {
        private IList<IObserverBodyPart> _subjects { get; set; } = new List<IObserverBodyPart>();
        public string Id { get; set; }
        public string Name
        {
            get
            {
                return $"Inclination";
            }
        }

        public IStateMachine StateMachine { get; }

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

        public override bool Previous()
        {
            var output = base.Previous();
            Notify();

            return output;
        }

        public override bool Next()
        {
            var output = base.Next();
            Notify();

            return output;
        }
    }
}
