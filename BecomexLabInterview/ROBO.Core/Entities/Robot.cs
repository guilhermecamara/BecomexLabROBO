using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ROBO.Core.Entities {
    public class Robot : IRobot
    {        
        public IEnumerable<IBodyPartCollection> BodyPartCollection { get; }
        public string Name { get; set; }

        public Robot(IEnumerable<IBodyPartCollection> bodyPartCollection)
        {
            BodyPartCollection = bodyPartCollection;
        }

        public bool SetNextStateOfBodyPart(string bodyPartCollectionId, string bodyPartId)
        {
            var bodyPart = GetBodyPart(bodyPartCollectionId, bodyPartId);

            if (bodyPart != null)
            {
                return bodyPart.StateMachine.Next();
            }

            return false;
        }

        public bool SetPreviousStateOfBodyPart(string bodyPartCollectionId, string bodyPartId)
        {
            var bodyPart = GetBodyPart(bodyPartCollectionId, bodyPartId);

            if (bodyPart != null)
            {
                return bodyPart.StateMachine.Previous();
            }

            return false;
        }

        public IBodyPart GetBodyPart(string bodyPartCollectionId, string bodyPartId)
        {
            var bodyPartCollection = GetBodyPartCollection(bodyPartCollectionId);

            if (bodyPartCollection != null)
            { 
                return bodyPartCollection.GetBodyPart(bodyPartId);
            }

            return null;
        }

        public IBodyPartCollection GetBodyPartCollection(string id) {
            var bodyPartCollection = BodyPartCollection.FirstOrDefault(x => x.Id == id);

            return bodyPartCollection;
        }
    }
}
