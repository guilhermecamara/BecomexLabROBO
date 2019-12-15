using System;
using System.Collections.Generic;
using System.Text;

namespace ROBO.Core.Entities
{
    public class ArmUpdateStrategy : IUpdateStrategy
    {
        public void Update(IBodyPart observable, IBodyPart context)
        {
            if (observable.StateMachine.GetState().StateEnum == StateEnum.StronglyContracted)
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
