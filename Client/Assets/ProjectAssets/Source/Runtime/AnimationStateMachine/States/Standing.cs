using Assets.ProjectAssets.Source.Runtime.AnimationStateMachine.Contracts;
using Assets.ProjectAssets.Source.Runtime.AnimationStateMachine.Enums;
using UnityEngine;

namespace Assets.ProjectAssets.Source.Runtime.AnimationStateMachine.States
{
    public class Standing : BaseState
    {
        public Standing(StateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override State Name => State.STANDING;

        public override void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.ChangeState(new Jumping(stateMachine));
            }
            else if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                stateMachine.ChangeState(new Ducking(stateMachine));
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                stateMachine.ChangeState(new Running(stateMachine));
            }
            else if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.LeftShift))
            {
                stateMachine.ChangeState(new Walking(stateMachine));
            }
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
