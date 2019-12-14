using System;
using System.Collections.Generic;
using System.Text;

namespace ROBODomain.RobotStateMachine.StateMachineStrategies
{
    public class HeadUpdateStrategy : IUpdateStrategy
    {
        public void Update(IObservableStateMachine observable, IObserverStateMachine context)
        {
            if (observable.StateMachine.GetState().StateName != StateEnum.Downwards)
            {
                context.StateMachine.CanModify = true;
            }

            context.StateMachine.CanModify = false;
        }
    }
}
