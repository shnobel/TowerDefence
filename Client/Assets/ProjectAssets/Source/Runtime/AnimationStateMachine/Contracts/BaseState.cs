using Assets.ProjectAssets.Source.Runtime.AnimationStateMachine.Enums;
using UnityEngine;

namespace Assets.ProjectAssets.Source.Runtime.AnimationStateMachine.Contracts
{
    public abstract class BaseState
    {
        protected StateMachine stateMachine;

        protected BaseState(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        protected abstract State Name { get; }

        public abstract void HandleInput();

        public abstract void Update();

        public virtual void Entry()
        {
            Debug.Log($"State {Name} started");
        }

        public virtual void Exit()
        {
            Debug.Log($"State {Name} finished");
        }

    }
}
