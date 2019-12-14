using ROBODomain.RobotParts;
using ROBODomain.RobotStateMachine;
using ROBODomain.RobotStateMachine.StateMachineStrategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROBODomain
{
    public class RobotFabric
    {
        public IRobot CreateRobot() {
            var bodyParts = new List<IBodyPart>() {
                CreateHead(),
                CreateLeftArm(),
                CreateRightArm()
            };

            return new Robot(bodyParts);
        }

        public IHead CreateHead() {
            var headRotationUpdateStrategy = CreateHeadUpdateStrategy();
            var headRotationStateMachine = CreateHeadRotationStateMachine();
            var headRotationObserver = CreateObserverStateMachine(headRotationStateMachine, headRotationUpdateStrategy);

            var headInclinationStateMachine = CreateHeadInclinationStateMachine();
            var headInclinationObservable = CreateObservableStateMachine(headInclinationStateMachine);

            return new Head(headInclinationObservable, headRotationObserver);
        }

        public IArm CreateRightArm()
        {
            var arm = CreateArm();
            arm.BodySide = BodySideEnum.Right;

            return arm;
        }

        public IArm CreateLeftArm()
        {            
            var arm = CreateArm();
            arm.BodySide = BodySideEnum.Left;

            return arm;
        }

        private IArm CreateArm()
        {
            var armUpdateStrategy = CreateArmUpdateStrategy();
            var wristStateMachine = CreateWristStateMachine();
            var wristObserver = CreateObserverStateMachine(wristStateMachine, armUpdateStrategy);

            var elbowStateMachine = CreateElbowStateMachine();
            var elbowObservable = CreateObservableStateMachine(elbowStateMachine);

            return new Arm(elbowObservable, wristObserver);
        }

        public IObservableStateMachine CreateObservableStateMachine(IStateMachine stateMachine) {
            
            return new ObservableStateMachine(stateMachine);
        }

        public IObserverStateMachine CreateObserverStateMachine(IStateMachine stateMachine, IUpdateStrategy updateStrategy)
        {
            return new ObserverStateMachine(stateMachine, updateStrategy);
        }

        public IStateMachine CreateElbowStateMachine()
        {
            var states = new List<IState>() {
                CreateState(StateEnum.Resting),
                CreateState(StateEnum.SlighlyContracted),
                CreateState(StateEnum.Contracted),
                CreateState(StateEnum.StronglyContracted)
            };

            return new StateMachine(states);
        }

        public IStateMachine CreateWristStateMachine()
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

            return new StateMachine(states);
        }

        public IStateMachine CreateHeadRotationStateMachine()
        {
            var states = new List<IState>() {
                CreateState(StateEnum.RotationOfMinus90Degrees),
                CreateState(StateEnum.RotationOfMinus45Degrees),
                CreateState(StateEnum.Resting),
                CreateState(StateEnum.RotationOf45Degrees),
                CreateState(StateEnum.RotationOf90Degrees)
            };

            return new StateMachine(states);
        }

        public IStateMachine CreateHeadInclinationStateMachine()
        {
            var states = new List<IState>() {
                CreateState(StateEnum.Upwards),
                CreateState(StateEnum.Resting),
                CreateState(StateEnum.Downwards)
            };

            return new StateMachine(states);
        }

        public IState CreateState(StateEnum stateName) 
        {
            return new State() { StateName = stateName };
        }

        public IUpdateStrategy CreateArmUpdateStrategy()
        {
            return new ArmUpdateStrategy();
        }

        public IUpdateStrategy CreateHeadUpdateStrategy()
        {
            return new HeadUpdateStrategy();
        }
    }
}
