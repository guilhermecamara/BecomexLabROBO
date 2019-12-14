
namespace ROBO.Core
{
    public interface IArm : IBodyPartCollection
    {
        BodySideEnum BodySide { get; set; }
    }
}