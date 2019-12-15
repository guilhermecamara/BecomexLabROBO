using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ROBO.Core.Entities
{
    public class Head : IHead
    {
        public string Id { get; set; }
        public string Name
        {
            get
            {
                return $"Head";
            }
        }
        public IEnumerable<IBodyPart> BodyParts { get; }

        public Head(IEnumerable<IBodyPart> bodyParts)
        {
            BodyParts = bodyParts;
        }

        public IBodyPart GetBodyPart(string id)
        {
            return BodyParts.FirstOrDefault(x => x.Id == id);
        }
    }
}
