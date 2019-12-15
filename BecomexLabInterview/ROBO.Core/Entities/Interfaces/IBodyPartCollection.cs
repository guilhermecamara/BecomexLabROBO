using System.Collections.Generic;

namespace ROBO.Core.Entities
{
    public interface IBodyPartCollection : IEntity
    {
        string Name { get; }
        IEnumerable<IBodyPart> BodyParts { get; }

        IBodyPart GetBodyPart(string id);
    }
}