using System;
using System.Collections.Generic;
using System.Text;

namespace ROBODomain
{
    public class Rotation : IObserverBodyPart
    {
        private IUpdateStrategy _updateStrategy { get; set; }
        public string Name
        {
            get
            {
                return $"Rotation";
            }
        }
        public IStateMachine StateMachine { get; }        

        public Rotation(IStateMachine stateMachine, IUpdateStrategy updateStrategy)
        {
            StateMachine = stateMachine;
            _updateStrategy = updateStrategy;
        }        

        public void Update(IBodyPart observable)
        {
            _updateStrategy.Update(observable, this);
        }
    }
}
