using ROBO.Core.Entities;
using ROBO.Core.Interactors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace ROBO.Core.Test
{
    public class RequestNextStateOfBodyPartInteractorTest
    {
        public static IState CreateTestState(StateEnum stateName)
        {
            return new State() { StateEnum = stateName };
        }

        public StateMachine CreateTestStateMachine() {

            var states = new List<IState>() {
                CreateTestState(StateEnum.Resting),
                CreateTestState(StateEnum.SlighlyContracted),
                CreateTestState(StateEnum.Contracted),
                CreateTestState(StateEnum.StronglyContracted)
            };

            var testStateMachine = new StateMachine();
            testStateMachine.SetStates(states);

            return testStateMachine;
        }

        [Fact]
        public void Handle_CanModify_Test()
        {
            //arrange            
            var inclination = new Inclination(CreateTestStateMachine());
            inclination.StateMachine.CanModify = true;

            var head = new Head(new List<IBodyPart>() {
                inclination
            });

            var robot = new Robot(new List<IBodyPartCollection>() {
                head
            });

            //act
            var request = new RequestNextStateOfBodyPartInteractor(robot);

            var requestMessage = new NextStateOfBodyPartRequestMessage(head.Id, inclination.Id);

            var responseTask = request.Handle(requestMessage, CancellationToken.None);

            responseTask.Wait();            

            //assert
            Assert.NotNull(responseTask);
            Assert.NotNull(responseTask.Result);
            Assert.True(responseTask.Result.Success);
        }

        [Fact]
        public void Handle_CanModify_Test1()
        {
            //arrange
            var inclination = new Inclination(CreateTestStateMachine());
            inclination.StateMachine.CanModify = false;

            var head = new Head(new List<IBodyPart>() {
                inclination
            });

            var robot = new Robot(new List<IBodyPartCollection>() {
                head
            });

            //act
            var request = new RequestNextStateOfBodyPartInteractor(robot);

            var requestMessage = new NextStateOfBodyPartRequestMessage(head.Id, inclination.Id);

            var responseTask = request.Handle(requestMessage, CancellationToken.None);

            responseTask.Wait();

            //assert
            Assert.NotNull(responseTask);
            Assert.NotNull(responseTask.Result);
            Assert.False(responseTask.Result.Success);
        }

        [Fact]
        public void Handle_LastState_Test1()
        {
            //arrange            
            var stateMachine = CreateTestStateMachine();
            stateMachine.CurrentState = stateMachine.States.Count() - 1;

            var inclination = new Inclination(stateMachine);

            var head = new Head(new List<IBodyPart>() {
                inclination
            });

            var robot = new Robot(new List<IBodyPartCollection>() {
                head
            });

            //act
            var request = new RequestNextStateOfBodyPartInteractor(robot);

            var requestMessage = new NextStateOfBodyPartRequestMessage(head.Id, inclination.Id);

            var responseTask = request.Handle(requestMessage, CancellationToken.None);

            responseTask.Wait();

            //assert
            Assert.NotNull(responseTask);
            Assert.NotNull(responseTask.Result);
            Assert.False(responseTask.Result.Success);
        }
    }
}
