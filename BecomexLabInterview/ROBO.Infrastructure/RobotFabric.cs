using ROBO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROBO.Infrastructure
{
    public class RobotFabric
    {
        // Mantem o robo padrão em memoria de aplicação enquanto nao existe algum tipo de persistencia
        private static IRobot Robot { get; set; } = RobotFabric.CreateDefaultRobot();

        public static IRobot GetDefaultRobot()
        {
            return Robot;
        }

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
            var wristStateMachine = CreateWristStateList();
            var wristUpdateStrategy = CreateArmUpdateStrategy();

            var wrist = new Wrist(wristUpdateStrategy) { Id = GenerateGuidId() };

            wrist.SetStates(wristStateMachine);

            return wrist;
        }

        public static IObservableBodyPart CreateElbow()
        {
            var elbowStateMachine = CreateElbowStateList();
            var elbow = new Elbow() { Id = GenerateGuidId() };

            elbow.SetStates(elbowStateMachine);

            return elbow;
        }

        public static IObserverBodyPart CreateRotation()
        {
            var rotationStateMachine = CreateHeadRotationStateList();
            var rotationUpdateStrategy = CreateHeadUpdateStrategy();

            var rotation = new Rotation(rotationUpdateStrategy) { Id = GenerateGuidId() };
            rotation.SetStates(rotationStateMachine);

            return rotation;
        }

        public static IObservableBodyPart CreateInclination()
        {
            var inclinationStateMachine = CreateHeadInclinationStateList();
            var rotation = new Inclination() { Id = GenerateGuidId() };

            rotation.SetStates(inclinationStateMachine);

            return rotation;
        }

        public static List<IState> CreateElbowStateList()
        {
            return new List<IState>() {
                CreateState(StateEnum.Resting),
                CreateState(StateEnum.SlighlyContracted),
                CreateState(StateEnum.Contracted),
                CreateState(StateEnum.StronglyContracted)
            };
        }

        public static List<IState> CreateWristStateList()
        {
            return new List<IState>() {
                CreateState(StateEnum.RotationOfMinus90Degrees),
                CreateState(StateEnum.RotationOfMinus45Degrees),
                CreateState(StateEnum.Resting),
                CreateState(StateEnum.RotationOf45Degrees),
                CreateState(StateEnum.RotationOf90Degrees),
                CreateState(StateEnum.RotationOf135Degrees),
                CreateState(StateEnum.RotationOf180Degrees)
            };
        }

        public static List<IState> CreateHeadRotationStateList()
        {
            return new List<IState>() {
                CreateState(StateEnum.RotationOfMinus90Degrees),
                CreateState(StateEnum.RotationOfMinus45Degrees),
                CreateState(StateEnum.Resting),
                CreateState(StateEnum.RotationOf45Degrees),
                CreateState(StateEnum.RotationOf90Degrees)
            };
        }

        public static List<IState> CreateHeadInclinationStateList()
        {
            return new List<IState>() {
                CreateState(StateEnum.Upwards),
                CreateState(StateEnum.Resting),
                CreateState(StateEnum.Downwards)
            };
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
