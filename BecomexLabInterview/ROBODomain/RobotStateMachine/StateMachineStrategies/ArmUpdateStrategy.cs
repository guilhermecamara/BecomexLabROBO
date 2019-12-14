using System;
using System.Collections.Generic;
using System.Text;

namespace ROBODomain.RobotStateMachine.StateMachineStrategies
{
    public class ArmUpdateStrategy : IUpdateStrategy
    {
        public void Update(IObservableStateMachine observable, IObserverStateMachine context)
        {
            if (observable.StateMachine.GetState().StateName == StateEnum.StronglyContracted)
            {
                context.StateMachine.CanModify = true;
            }

            context.StateMachine.CanModify = false;
        }
    }
}
