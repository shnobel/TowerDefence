using Assets.ProjectAssets.Source.Runtime.AnimationStateMachine.Contracts;
using Assets.ProjectAssets.Source.Runtime.AnimationStateMachine.Enums;
using System;
using UnityEngine;

namespace Assets.ProjectAssets.Source.Runtime.AnimationStateMachine.States
{
    public class Jumping : BaseState
    {
        public Jumping(StateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override State Name => State.JUMPING;

        public override void HandleInput()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                stateMachine.ChangeState(new Standing(stateMachine));
            }
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
