using System.Collections.Generic;
using ROBODomain.GeneralInterfaces;
using ROBODomain.RobotParts;

namespace ROBODomain
{
    public interface IRobot : Identity
    {
        IEnumerable<IBodyPart> BodyParts { get; }
        string Name { get; set; }
    }
}