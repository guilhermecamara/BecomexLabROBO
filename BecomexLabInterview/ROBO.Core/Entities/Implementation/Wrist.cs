using System;
using System.Collections.Generic;
using System.Text;

namespace ROBO.Core.Entities
{
    public class Wrist : EntityBase, IObserverBodyPart
    {
        private IUpdateStrategy _updateStrategy { get; set; }
        public string Name
        {
            get
            {
                return $"Wirst";
            }
        }
        public IStateMachine StateMachine { get; }

        public Wrist(IStateMachine stateMachine, IUpdateStrategy updateStrategy)
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
