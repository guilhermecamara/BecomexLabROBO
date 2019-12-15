using System.Collections.Generic;

namespace ROBO.Core.Entities
{
    public interface IBodyPart : IEntity
    {   
        string Name { get; }

        IStateMachine StateMachine { get; }
    }
}