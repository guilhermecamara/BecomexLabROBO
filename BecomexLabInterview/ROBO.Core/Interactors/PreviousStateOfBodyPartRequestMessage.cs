using MediatR;

namespace ROBO.Core.Interactors
{
    public class PreviousStateOfBodyPartRequestMessage : IRequest<ChangeStateOfBodyPartResponseMessage>
    {
        public string bodyPartCollectionId { get; private set; }
        public string bodyPartId { get; private set; }

        public PreviousStateOfBodyPartRequestMessage(string bodyPartCollectionId, string bodyPartId)
        {
            this.bodyPartCollectionId = bodyPartCollectionId;
            this.bodyPartId = bodyPartId;
        }
    }
}