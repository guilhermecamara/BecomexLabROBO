namespace ROBO.Core
{
    public interface IObservableBodyPart : IBodyPart
    {
        void Attach(IObserverBodyPart subject);
        void Detach(IObserverBodyPart subject);
        void Notify();
    }
}