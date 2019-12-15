using ROBO.Core.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace ROBO.Core.Test
{
    public class RobotTest
    {       

        [Fact]
        public void GetBodyPart_Test()
        {
            //arrange
            var inclination = new Inclination(null);

            var head = new Head(new List<IBodyPart>() {
                inclination
            });
            
            var robot = new Robot(new List<IBodyPartCollection>() {
                head
            });

            //act
            var part = robot.GetBodyPart(head.Id, inclination.Id);

            //assert
            Assert.NotNull(part);
            Assert.Equal(inclination, part);
        }

        [Fact]
        public void GetBodyPart_Test_1()
        {
            //arrange
            var inclination = new Inclination(null);

            var head = new Head(new List<IBodyPart>());

            var robot = new Robot(new List<IBodyPartCollection>() {
                head
            });

            //act
            var part = robot.GetBodyPart(head.Id, inclination.Id);

            //assert
            Assert.Null(part);
        }

        [Fact]
        public void GetBodyPartCollection_Test()
        {
            var head = new Head(new List<IBodyPart>());

            var robot = new Robot(new List<IBodyPartCollection>() {
                head
            });

            //act
            var part = robot.GetBodyPartCollection(head.Id);

            //assert
            Assert.NotNull(part);
            Assert.Equal(head, part);
        }

        [Fact]
        public void GetBodyPartCollection_Test_1()
        {
            var head = new Head(new List<IBodyPart>());

            var robot = new Robot(new List<IBodyPartCollection>());

            //act
            var part = robot.GetBodyPartCollection(head.Id);

            //assert
            Assert.Null(part);
        }
    }
}
