using Assets.ProjectAssets.Source.Runtime.AnimationStateMachine.Contracts;
using Assets.ProjectAssets.Source.Runtime.AnimationStateMachine.Enums;
using System;
using UnityEngine;

namespace Assets.ProjectAssets.Source.Runtime.AnimationStateMachine.States
{
    public class Walking : BaseState
    {
        public Walking(StateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override State Name => State.WALKING;

        public override void HandleInput()
        {
            if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.LeftShift))
            {
                stateMachine.ChangeState(new Standing(stateMachine));
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                stateMachine.ChangeState(new Running(stateMachine));
            }
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}