
namespace ROBODomain
{
    public interface IObserverBodyPart : IBodyPart
    {
        void Update(IBodyPart observable);
    }
}