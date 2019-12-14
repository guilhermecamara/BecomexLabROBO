using System.Collections.Generic;

namespace ROBO.Core
{
    public interface IBodyPart
    {   
        string Name { get; }

        IStateMachine StateMachine { get; }
    }
}