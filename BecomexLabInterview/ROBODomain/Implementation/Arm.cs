using System;
using System.Collections.Generic;
using System.Text;

namespace ROBO.Core
{
    public class Arm : IArm
    {        
        public BodySideEnum BodySide { get ; set; }
        public string Name
        {
            get
            {
                return $"{BodySide.ToString()} arm";
            }
        }
        public IEnumerable<IBodyPart> BodyParts { get; }

        public Arm(IEnumerable<IBodyPart> bodyParts)
        {
            BodyParts = bodyParts;
        }
    }
}
