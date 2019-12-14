
namespace ROBO.Core
{
    public interface IObserverBodyPart : IBodyPart
    {
        void Update(IBodyPart observable);
    }
}