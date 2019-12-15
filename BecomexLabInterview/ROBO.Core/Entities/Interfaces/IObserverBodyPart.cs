
namespace ROBO.Core.Entities
{
    public interface IObserverBodyPart : IBodyPart
    {
        void Update(IBodyPart observable);
    }
}