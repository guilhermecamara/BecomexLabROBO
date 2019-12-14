namespace ROBO.Core
{
    public interface IUpdateStrategy
    {        
        void Update(IBodyPart observable, IBodyPart context);
    }
}