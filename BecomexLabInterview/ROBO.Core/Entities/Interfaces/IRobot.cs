using System.Collections.Generic;

namespace ROBO.Core.Entities
{
    public interface IRobot
    {
        string Name { get; set; }
        IEnumerable<IBodyPartCollection> BodyPartCollection { get; }

        bool SetNextStateOfBodyPart(string bodyPartCollectionName, string bodyPartName);

        bool SetPreviousStateOfBodyPart(string bodyPartCollectionName, string bodyPartName);

        IBodyPart GetBodyPart(string bodyPartCollectionId, string bodyPartId);

        IBodyPartCollection GetBodyPartCollection(string id);
    }
}