using System.Collections.Generic;

namespace ROBO.Core
{
    public interface IRobot
    {
        string Name { get; set; }
        IEnumerable<IBodyPartCollection> BodyPartCollection { get; }
    }
}