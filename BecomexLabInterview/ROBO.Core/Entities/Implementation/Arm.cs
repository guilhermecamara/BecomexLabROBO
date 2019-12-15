using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ROBO.Core.Entities
{
    public class Arm : EntityBase, IArm
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

        public IBodyPart GetBodyPart(string id)
        {
            return BodyParts.FirstOrDefault(x => x.Id == id);
        }
    }
}
