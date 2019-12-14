﻿namespace ROBODomain.RobotStateMachine
{
    public interface IObservableStateMachine
    {
        IStateMachine StateMachine { get; }

        void Attach(IObserverStateMachine subject);
        void Detach(IObserverStateMachine subject);
        void Notify();
    }
}