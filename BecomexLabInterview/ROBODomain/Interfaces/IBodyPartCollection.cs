using System.Collections.Generic;

namespace ROBODomain
{
    public interface IBodyPartCollection
    {
        string Name { get; }
        IEnumerable<IBodyPart> BodyParts { get; }
    }
}