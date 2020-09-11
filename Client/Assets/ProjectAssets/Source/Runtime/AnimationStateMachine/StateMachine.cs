using Assets.ProjectAssets.Source.Runtime.AnimationStateMachine.Contracts;

public class StateMachine
{
    public BaseState CurrentState { get; private set; }

    public void HandleInput()
    {
        CurrentState.HandleInput();
    }

    public void ChangeState(BaseState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Entry();
    }
}
