using System.Collections.Generic;

namespace ROBO.Core
{
    public interface IBodyPartCollection
    {
        string Name { get; }
        IEnumerable<IBodyPart> BodyParts { get; }
    }
}