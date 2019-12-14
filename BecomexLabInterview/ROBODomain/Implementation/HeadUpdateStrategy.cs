using System;
using System.Collections.Generic;
using System.Text;

namespace ROBODomain
{
    public class HeadUpdateStrategy : IUpdateStrategy
    {
        public void Update(IBodyPart observable, IBodyPart context)
        {
            if (observable.StateMachine.GetState().StateName != StateEnum.Downwards)
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
