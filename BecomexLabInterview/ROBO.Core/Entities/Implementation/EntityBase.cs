using System;
using System.Collections.Generic;
using System.Text;

namespace ROBO.Core.Entities
{
    public abstract class EntityBase : IEntity
    {
        public string Id { get; private set; }

        public EntityBase()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
