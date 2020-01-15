using UnityEngine;

public class GameController : MonoBehaviour
{
    private State currentState;

    void Start()
    {
        SetState(new Intro(this));
    }

    void Update()
    {
        currentState.Tick();
    }

    public void SetState(State state)
    {
        if(currentState != null)
            currentState.OnStateExit();

        currentState = state;

        if(currentState != null)
            currentState.OnStateEnter();
    }

}
