using MediatR;

namespace ROBO.Core.Interactors
{
    public class NextStateOfBodyPartRequestMessage : IRequest<ChangeStateOfBodyPartResponseMessage>
    {
        public string bodyPartCollectionId { get; private set; }
        public string bodyPartId { get; private set; }

        public NextStateOfBodyPartRequestMessage(string bodyPartCollectionId, string bodyPartId)
        {
            this.bodyPartCollectionId = bodyPartCollectionId;
            this.bodyPartId = bodyPartId;
        }
    }
}