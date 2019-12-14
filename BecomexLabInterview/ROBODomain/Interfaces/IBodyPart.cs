using System.Collections.Generic;

namespace ROBODomain
{
    public interface IBodyPart
    {   
        string Name { get; }

        IStateMachine StateMachine { get; }
    }
}