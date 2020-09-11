using Assets.ProjectAssets.Source.Runtime.AnimationStateMachine.Contracts;
using Assets.ProjectAssets.Source.Runtime.AnimationStateMachine.Enums;
using UnityEngine;

namespace Assets.ProjectAssets.Source.Runtime.AnimationStateMachine.States
{
    public class Ducking : BaseState
    {
        protected override State Name => State.DUCKING;

        public Ducking(StateMachine stateMachine) : base(stateMachine) { }

        public override void HandleInput()
        {
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                stateMachine.ChangeState(new Standing(stateMachine));
            }
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
