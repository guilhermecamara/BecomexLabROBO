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
    public class RequestPreviousStateOfBodyPartInteractorTest
    {
        public static IState CreateTestState(StateEnum stateName)
        {
            return new State() { StateEnum = stateName };
        }

        public List<IState> CreateTestListStates()
        {

            var states = new List<IState>() {
                CreateTestState(StateEnum.SlighlyContracted),
                CreateTestState(StateEnum.Contracted),
                CreateTestState(StateEnum.StronglyContracted),
                CreateTestState(StateEnum.Resting)
            };

            return states;
        }

        [Fact]
        public void Handle_CanModify_Test()
        {
            //arrange            
            var states = CreateTestListStates();
            var inclination = new Inclination();

            inclination.SetStates(states);
            inclination.CanModify = true;

            var head = new Head(new List<IBodyPart>() {
                inclination
            });

            var robot = new Robot(new List<IBodyPartCollection>() {
                head
            });

            //act
            var request = new RequestPreviousStateOfBodyPartInteractor(robot);

            var requestMessage = new PreviousStateOfBodyPartRequestMessage(head.Id, inclination.Id);

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
            var states = CreateTestListStates();
            var inclination = new Inclination();

            inclination.SetStates(states);
            inclination.CanModify = false;

            var head = new Head(new List<IBodyPart>() {
                inclination
            });

            var robot = new Robot(new List<IBodyPartCollection>() {
                head
            });

            //act
            var request = new RequestPreviousStateOfBodyPartInteractor(robot);

            var requestMessage = new PreviousStateOfBodyPartRequestMessage(head.Id, inclination.Id);

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
            var states = CreateTestListStates();
            var inclination = new Inclination();

            inclination.SetStates(states);
            inclination.CanModify = true;
            inclination.CurrentState = 0;

            var head = new Head(new List<IBodyPart>() {
                inclination
            });

            var robot = new Robot(new List<IBodyPartCollection>() {
                head
            });

            //act
            var request = new RequestPreviousStateOfBodyPartInteractor(robot);

            var requestMessage = new PreviousStateOfBodyPartRequestMessage(head.Id, inclination.Id);

            var responseTask = request.Handle(requestMessage, CancellationToken.None);

            responseTask.Wait();

            //assert
            Assert.NotNull(responseTask);
            Assert.NotNull(responseTask.Result);
            Assert.False(responseTask.Result.Success);
        }
    }
}
