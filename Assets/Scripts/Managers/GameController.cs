using UnityEngine;

public class GameController : MonoBehaviour
{
    private State currentState;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Setting Intro as first state
        // Hope I get to that point :P
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
