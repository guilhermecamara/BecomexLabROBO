using System;
using System.Collections.Generic;
using System.Text;

namespace ROBO.Core.Entities
{
    public class HeadUpdateStrategy : IUpdateStrategy
    {
        public void Update(IBodyPart observable, IBodyPart context)
        {
            if (observable.GetState().StateEnum != StateEnum.Downwards)
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
