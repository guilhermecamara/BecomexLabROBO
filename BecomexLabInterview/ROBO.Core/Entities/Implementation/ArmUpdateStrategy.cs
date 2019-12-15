using System;
using System.Collections.Generic;
using System.Text;

namespace ROBO.Core.Entities
{
    public class ArmUpdateStrategy : IUpdateStrategy
    {
        public void Update(IBodyPart observable, IBodyPart context)
        {
            if (observable.GetState().StateEnum == StateEnum.StronglyContracted)
            {
                context.CanModify = true;
            }
            else
            { 
                context.CanModify = false;
            }
        }
    }
}
