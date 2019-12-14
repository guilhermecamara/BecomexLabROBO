using System;
using System.Collections.Generic;
using System.Text;

namespace ROBODomain
{
    public class ArmUpdateStrategy : IUpdateStrategy
    {
        public void Update(IBodyPart observable, IBodyPart context)
        {
            if (observable.StateMachine.GetState().StateName == StateEnum.StronglyContracted)
            {
                context.StateMachine.CanModify = true;
            }
            else
            { 
                context.StateMachine.CanModify = false;
            }
        }
    }
}
