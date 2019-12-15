using System.Collections.Generic;

namespace ROBO.Core.Entities
{
    public interface IBodyPart : IStateMachine, IEntity
    {   
        string Name { get; }
    }
}