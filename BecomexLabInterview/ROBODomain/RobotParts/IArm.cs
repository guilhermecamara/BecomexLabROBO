using ROBODomain.StateMachine;

namespace ROBODomain.RobotParts
{
    public interface IArm : IBodyPart
    {
        BodySideEnum BodySide { get; set; }
    }
}