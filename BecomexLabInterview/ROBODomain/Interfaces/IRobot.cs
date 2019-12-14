using System.Collections.Generic;

namespace ROBODomain
{
    public interface IRobot
    {
        string Name { get; set; }
        IEnumerable<IBodyPartCollection> BodyPartCollection { get; }
    }
}