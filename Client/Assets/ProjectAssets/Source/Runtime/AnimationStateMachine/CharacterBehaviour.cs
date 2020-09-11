using Assets.ProjectAssets.Source.Runtime.AnimationStateMachine.States;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    StateMachine stateMachine;
    Standing standing;
    Running  running;
    Ducking  ducking;
    Jumping  jumping;
    Walking  walking;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new StateMachine();
        standing = new Standing(stateMachine);
        running = new Running(stateMachine);
        ducking = new Ducking(stateMachine);
        jumping = new Jumping(stateMachine);
        walking = new Walking(stateMachine);
        stateMachine.HandleInput();
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.HandleInput();
    }
}
