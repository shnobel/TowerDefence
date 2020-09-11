using Assets.ProjectAssets.Source.Runtime.AnimationStateMachine.Contracts;
using Assets.ProjectAssets.Source.Runtime.AnimationStateMachine.Enums;
using System;
using UnityEngine;

namespace Assets.ProjectAssets.Source.Runtime.AnimationStateMachine.States
{
    public class Running : BaseState
    {
        public Running(StateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override State Name => State.RUNNING;

        public override void HandleInput()
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                stateMachine.ChangeState(new Standing(stateMachine));
            }
            else if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.LeftShift))
            {
                stateMachine.ChangeState(new Walking(stateMachine));
            }
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
