
namespace ROBO.Core.Entities
{
    public interface IArm : IBodyPartCollection
    {
        BodySideEnum BodySide { get; set; }
    }
}