using ROBODomain.RobotParts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ROBODomain {
    public class Robot : IRobot
    {
        public int Id { get ; set; }
        public IEnumerable<IBodyPart> BodyParts { get; }
        public string Name { get; set; }

        public Robot(IEnumerable<IBodyPart> bodyParts)
        {
            BodyParts = bodyParts;
        }
    }
}
