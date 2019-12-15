using MediatR;
using ROBO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ROBO.Core.Interactors
{
    public class RequestNextStateOfBodyPartInteractor : IRequestHandler<NextStateOfBodyPartRequestMessage, ChangeStateOfBodyPartResponseMessage>
    {
        private readonly IRobot _robot;

        public RequestNextStateOfBodyPartInteractor(IRobot robot)
        {
            _robot = robot;
        }

        public Task<ChangeStateOfBodyPartResponseMessage> Handle(NextStateOfBodyPartRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                var success = _robot.SetNextStateOfBodyPart(request.bodyPartCollectionId, request.bodyPartId);

                return new ChangeStateOfBodyPartResponseMessage() { Success = success };
            });            
        }
    }
}
