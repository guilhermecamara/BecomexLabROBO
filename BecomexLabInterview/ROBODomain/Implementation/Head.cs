using System;
using System.Collections.Generic;
using System.Text;

namespace ROBO.Core
{
    public class Head : IHead
    {                
        public string Name
        {
            get
            {
                return $"Head";
            }
        }
        public IEnumerable<IBodyPart> BodyParts { get; }

        public Head(IEnumerable<IBodyPart> bodyParts)
        {
            BodyParts = bodyParts;
        }
    }
}
