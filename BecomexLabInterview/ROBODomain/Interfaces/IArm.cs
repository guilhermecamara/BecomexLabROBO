
namespace ROBODomain
{
    public interface IArm : IBodyPartCollection
    {
        BodySideEnum BodySide { get; set; }
    }
}