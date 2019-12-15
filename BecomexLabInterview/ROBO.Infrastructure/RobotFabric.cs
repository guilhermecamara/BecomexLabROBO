using ROBO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROBO.Infrastructure
{
    public class RobotFabric
    {
        public static IRobot CreateDefaultRobot() {
            var bodyParts = new List<IBodyPartCollection>() {
                CreateHead(),
                CreateLeftArm(),
                CreateRightArm()
            };

            return new Robot(bodyParts);
        }

        public static IHead CreateHead() {
            var rotation = CreateRotation();
            var inclination = CreateInclination();

            inclination.Attach(rotation);

            var bodyParts = new List<IBodyPart>() {
                rotation,
                inclination
            };
            
            return new Head(bodyParts) { Id = GenerateGuidId() };
        }        

        public static IArm CreateRightArm()
        {
            var arm = CreateArm();
            arm.BodySide = BodySideEnum.Right;

            return arm;
        }       

        public static IArm CreateLeftArm()
        {            
            var arm = CreateArm();
            arm.BodySide = BodySideEnum.Left;

            return arm;
        }

        private static IArm CreateArm()
        {
            var elbow = CreateElbow();
            var wrist = CreateWrist();

            elbow.Attach(wrist);

            var bodyParts = new List<IBodyPart>() {
                elbow,
                wrist
            };

            return new Arm(bodyParts) { Id = GenerateGuidId() };
        }

        public static IObserverBodyPart CreateWrist()
        {
            var wristStateMachine = CreateWristStateMachine();
            var wristUpdateStrategy = CreateArmUpdateStrategy();

            return new Wrist(wristStateMachine, wristUpdateStrategy) { Id = GenerateGuidId() };
        }

        public static IObservableBodyPart CreateElbow()
        {
            var elbowStateMachine = CreateElbowStateMachine();
            return new Elbow(elbowStateMachine) { Id = GenerateGuidId() };
        }

        public static IObserverBodyPart CreateRotation()
        {
            var rotationStateMachine = CreateHeadRotationStateMachine();
            var rotationUpdateStrategy = CreateHeadUpdateStrategy();

            return new Rotation(rotationStateMachine, rotationUpdateStrategy) { Id = GenerateGuidId() };
        }

        public static IObservableBodyPart CreateInclination()
        {
            var inclinationStateMachine = CreateHeadInclinationStateMachine();
            return new Inclination(inclinationStateMachine) { Id = GenerateGuidId() };
        }

        public static IStateMachine CreateElbowStateMachine()
        {
            var states = new List<IState>() {
                CreateState(StateEnum.Resting),
                CreateState(StateEnum.SlighlyContracted),
                CreateState(StateEnum.Contracted),
                CreateState(StateEnum.StronglyContracted)
            };

            var elbowStateMachine = new StateMachine();
            elbowStateMachine.SetStates(states);
            return elbowStateMachine;
        }

        public static IStateMachine CreateWristStateMachine()
        {
            var states = new List<IState>() {
                CreateState(StateEnum.RotationOfMinus90Degrees),
                CreateState(StateEnum.RotationOfMinus45Degrees),
                CreateState(StateEnum.Resting),
                CreateState(StateEnum.RotationOf45Degrees),
                CreateState(StateEnum.RotationOf90Degrees),
                CreateState(StateEnum.RotationOf135Degrees),
                CreateState(StateEnum.RotationOf180Degrees)
            };

            var wristStateMachine = new StateMachine();
            wristStateMachine.SetStates(states);
            return wristStateMachine;
        }

        public static IStateMachine CreateHeadRotationStateMachine()
        {
            var states = new List<IState>() {
                CreateState(StateEnum.RotationOfMinus90Degrees),
                CreateState(StateEnum.RotationOfMinus45Degrees),
                CreateState(StateEnum.Resting),
                CreateState(StateEnum.RotationOf45Degrees),
                CreateState(StateEnum.RotationOf90Degrees)
            };

            var rotationStateMachine = new StateMachine();
            rotationStateMachine.SetStates(states);
            return rotationStateMachine;
        }

        public static IStateMachine CreateHeadInclinationStateMachine()
        {
            var states = new List<IState>() {
                CreateState(StateEnum.Upwards),
                CreateState(StateEnum.Resting),
                CreateState(StateEnum.Downwards)
            };

            var inclinationStateMachine = new StateMachine();
            inclinationStateMachine.SetStates(states);
            return inclinationStateMachine;
        }

        public static IState CreateState(StateEnum stateName) 
        {
            return new State() { StateEnum = stateName };
        }

        public static IUpdateStrategy CreateArmUpdateStrategy()
        {
            return new ArmUpdateStrategy();
        }

        public static IUpdateStrategy CreateHeadUpdateStrategy()
        {
            return new HeadUpdateStrategy();
        }

        private static string GenerateGuidId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
