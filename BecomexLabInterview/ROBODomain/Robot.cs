using System;
using System.Collections;
using System.Collections.Generic;

namespace ROBO.Core {
    public class Robot : IRobot
    {        
        public IEnumerable<IBodyPartCollection> BodyPartCollection { get; }
        public string Name { get; set; }

        public Robot(IEnumerable<IBodyPartCollection> bodyPartCollection)
        {
            BodyPartCollection = bodyPartCollection;
        }
    }
}
