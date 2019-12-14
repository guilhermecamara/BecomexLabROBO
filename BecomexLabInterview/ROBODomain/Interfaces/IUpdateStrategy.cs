namespace ROBODomain
{
    public interface IUpdateStrategy
    {        
        void Update(IBodyPart observable, IBodyPart context);
    }
}