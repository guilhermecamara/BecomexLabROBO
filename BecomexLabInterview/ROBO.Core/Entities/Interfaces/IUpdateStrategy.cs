namespace ROBO.Core.Entities
{
    public interface IUpdateStrategy
    {        
        void Update(IBodyPart observable, IBodyPart context);
    }
}