using System;
using System.Collections.Generic;
using System.Text;

namespace ROBO.Core.Entities
{
    public class Wrist : StateMachine, IObserverBodyPart
    {
        private IUpdateStrategy _updateStrategy { get; set; }
        public string Id { get; set; }
        public string Name
        {
            get
            {
                return $"Wirst";
            }
        }
        public Wrist(IUpdateStrategy updateStrategy)
        {            
            _updateStrategy = updateStrategy;
        }

        public void Update(IBodyPart observable)
        {
            _updateStrategy.Update(observable, this);
        }
    }
}
