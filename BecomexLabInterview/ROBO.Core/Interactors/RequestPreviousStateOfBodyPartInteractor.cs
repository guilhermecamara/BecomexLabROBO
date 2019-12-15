using MediatR;
using ROBO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ROBO.Core.Interactors
{
    public class RequestPreviousStateOfBodyPartInteractor : IRequestHandler<PreviousStateOfBodyPartRequestMessage, ChangeStateOfBodyPartResponseMessage>
    {
        private readonly IRobot _robot;

        public RequestPreviousStateOfBodyPartInteractor(IRobot robot)
        {
            _robot = robot;
        }

        public Task<ChangeStateOfBodyPartResponseMessage> Handle(PreviousStateOfBodyPartRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                var success = _robot.SetPreviousStateOfBodyPart(request.bodyPartCollectionId, request.bodyPartId);

                return new ChangeStateOfBodyPartResponseMessage() { Success = success };
            });            
        }
    }
}
